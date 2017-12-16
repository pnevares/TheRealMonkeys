using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoneController : MonoBehaviour {
    private GameController gameController;

    private void Start() {
        GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
        gameController = gameControllerObject.GetComponent<GameController> ();
    }

    private void OnMouseDown() {
        gameController.Done ();
    }
}
