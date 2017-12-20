using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
    [Range(4, 8)]
    public int monkeyCount;
    public GameObject monkey;
    public GameObject doneButton;

    private bool gameOver = false;
    private List<GameObject> monkeys;

    private void Start () {
        int realMonkeys = Random.Range (1, 4);

        monkeys = new List<GameObject> ();
        for (int i = 0; i < monkeyCount; i++) {
            monkeys.Add((GameObject)Instantiate (monkey));
            if (i < realMonkeys) {
                MonkeyController monkeyController = monkeys [i].GetComponent<MonkeyController> ();
                monkeyController.SetReal (true);
            }
        }
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
        SceneManager.LoadScene ("Game", LoadSceneMode.Single);
    }
}
