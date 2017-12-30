using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
    [Range(2, 8)]
    public int monkeyCount;
    public GameObject monkey;
    public GameObject doneButton;
    public bool tutorial = false;
    public GameObject tutorialCursor;

    private bool gameOver = false;
    private List<GameObject> monkeys;

    private void Start () {
        int realMonkeys;

        if (tutorial) {
            realMonkeys = 1;
        } else {
            realMonkeys = Random.Range (1, 4);
        }

        monkeys = new List<GameObject> ();
        for (int i = 0; i < monkeyCount; i++) {
            monkeys.Add((GameObject)Instantiate (monkey));
            if (i < realMonkeys) {
                MonkeyController monkeyController = monkeys [i].GetComponent<MonkeyController> ();
                monkeyController.SetReal (true);
            }
        }

        if (tutorial) {
            StartCoroutine (Tutorial());
        }
	}

    IEnumerator Tutorial() {
        MonkeyController realTutorialMonkeyController = monkeys [0].GetComponent<MonkeyController> ();
        MonkeyController fakeTutorialMonkeyController = monkeys [1].GetComponent<MonkeyController> ();
        realTutorialMonkeyController.SetPatrol (false);
        fakeTutorialMonkeyController.SetPatrol (false);
        yield return new WaitForSeconds (0.5f);

        // wait for fake monkey to move into position
        fakeTutorialMonkeyController.SetDestination (new Vector2 (2f, 0f));
        fakeTutorialMonkeyController.SetSpeed (3f);
        fakeTutorialMonkeyController.PlayMoveSound();
        yield return new WaitForSeconds (2);

        // wait for real monkey to move into position
        realTutorialMonkeyController.SetDestination (new Vector2 (-2f, 0f));
        realTutorialMonkeyController.SetSpeed (3f);
        yield return new WaitForSeconds (2);

        // move cursor to real monkey and select
        Vector2 originalCursorPosition = tutorialCursor.transform.position;
        float percentageComplete = 0f;
        float moveStartTime = Time.time;
        while((tutorialCursor.transform.position - realTutorialMonkeyController.transform.position).sqrMagnitude > 0.1) {
            percentageComplete = (Time.time - moveStartTime) / 1.5f;
            tutorialCursor.transform.position = Vector3.Lerp (originalCursorPosition, realTutorialMonkeyController.transform.position, percentageComplete);
            yield return null;
        }
        realTutorialMonkeyController.ToggleSelected ();

        // move cursor to Done button and click
        originalCursorPosition = tutorialCursor.transform.position;
        percentageComplete = 0f;
        moveStartTime = Time.time;
        while (!tutorialCursor.transform.position.Equals(doneButton.transform.position)) {
            percentageComplete = (Time.time - moveStartTime) / 1.5f;
            tutorialCursor.transform.position = Vector3.Lerp (originalCursorPosition, doneButton.transform.position, percentageComplete);
            yield return null;
        }
        Done ();
    }

    public void Done() {
        doneButton.SetActive (false);

        Vector2 monkeyPosition = new Vector2 (-5.5f, 3.5f);
        foreach (GameObject monkey in monkeys) {
            MonkeyController monkeyController = monkey.GetComponent<MonkeyController> ();

            gameOver = true;
            monkeyController.SetSpeed (3f);
            monkeyController.SetDestination (monkeyPosition);
            monkeyPosition.x += 1.5f;
        }
    }

    public bool IsGameOver() {
        return gameOver;
    }

    public void Restart() {
        SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
    }
}
