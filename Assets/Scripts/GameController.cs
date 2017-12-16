﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
    public Text resultsText;
    public GameObject monkey;
    public GameObject doneButton;

    private List<GameObject> monkeys;

    private void Start () {
        resultsText.text = "";

        monkeys = new List<GameObject> ();
        for (int i = 0; i < 6; i++) {
            monkeys.Add((GameObject)Instantiate (monkey));
        }
	}

    public void Done() {
        // "Talk Is Cheap" - sort monkeys into real and fake columns, persisting selection arrows

        doneButton.SetActive (false);

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

    public void Restart() {
        SceneManager.LoadScene ("Game", LoadSceneMode.Single);
    }
}
