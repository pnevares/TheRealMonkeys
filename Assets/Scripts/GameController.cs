using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
    public Text resultsText;
    public GameObject monkey;
    public GameObject doneButton;

    private bool noText = true;
    private List<GameObject> monkeys;

    private void Start () {
        resultsText.text = "";

        monkeys = new List<GameObject> ();
        for (int i = 0; i < 6; i++) {
            monkeys.Add((GameObject)Instantiate (monkey));
        }
	}

    public void Done() {
        doneButton.SetActive (false);

        if (noText) {
            Vector2 monkeyPosition = new Vector2 (-5.5f, 3.5f);
            foreach (GameObject monkey in monkeys) {
                MonkeyController monkeyController = monkey.GetComponent<MonkeyController> ();

                monkeyController.Pause ();
                monkeyController.SetDestination (monkeyPosition);
                monkeyPosition.x += 1.5f;
            }
        } else {
            int realMonkeysFound = 0;
            int realMonkeysMissed = 0;
            int fakeMonkeysSelected = 0;
            foreach (GameObject monkey in monkeys) {
                MonkeyController monkeyController = monkey.GetComponent<MonkeyController> ();
                if (monkeyController.IsReal ()) {
                    if (monkeyController.IsSelected ()) {
                        realMonkeysFound++;
                    } else {
                        realMonkeysMissed++;
                    }
                } else if (monkeyController.IsSelected ()) {
                    fakeMonkeysSelected++;
                }
                Destroy (monkey);
            }

            resultsText.text = realMonkeysFound + " real monkeys found\n" +
            realMonkeysMissed + " real monkeys missed\n" +
            "Fooled by " + fakeMonkeysSelected + " fake monkeys";
        }
    }

    public void Restart() {
        SceneManager.LoadScene ("Game", LoadSceneMode.Single);
    }
}
