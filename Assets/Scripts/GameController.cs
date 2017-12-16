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
        // get count of monkeys

        // poll each monkey for Selected and Real states

        // calculate success rate

        // output to screen

        // "Talk Is Cheap" - sort monkeys into real and fake columns, persisting selection arrows

        // show restart button


        int realMonkeys = 0;
        int realMonkeysFound = 0;
        foreach (GameObject monkey in monkeys) {
            MonkeyController monkeyController = monkey.GetComponent<MonkeyController> ();
            if (monkeyController.IsReal ()) {
                realMonkeys++;
                if (monkeyController.IsSelected ()) {
                    realMonkeysFound++;
                }
            }
        }

        resultsText.text = realMonkeys + " real monkeys\n" + realMonkeysFound + " real monkeys found";
    }

    void MainMenu() {
        // Start Game button
    }
}
