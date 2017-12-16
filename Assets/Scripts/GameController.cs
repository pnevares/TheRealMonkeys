using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
    public GameObject monkey;
    public Text resultsText;

    private List<GameObject> monkeys;

    private void Start () {
        resultsText.text = "";

        monkeys = new List<GameObject> ();
        for (int i = 0; i < 6; i++) {
            monkeys.Add((GameObject)Instantiate (monkey));
        }
	}

    public void Done() {
        // output to screen

        // "Talk Is Cheap" - sort monkeys into real and fake columns, persisting selection arrows

        // show restart button


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
        }

        resultsText.text = realMonkeysFound + " real monkeys found\n" +
            realMonkeysMissed + " real monkeys missed\n" +
            "Fooled by " + fakeMonkeysSelected + " fake monkeys";
    }

    void MainMenu() {
        // Start Game button
    }
}
