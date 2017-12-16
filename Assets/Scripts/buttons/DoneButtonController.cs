using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoneButtonController : MonoBehaviour {
    private SpriteRenderer sprite;
    private GameController gameController;

    private void Start() {
        sprite = GetComponent<SpriteRenderer> ();
        GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
        gameController = gameControllerObject.GetComponent<GameController> ();
    }

    private void OnMouseDown() {
        gameController.Done ();
    }

    private void OnMouseEnter() {
        sprite.color = Color.white;
    }

    private void OnMouseExit() {
        sprite.color = Color.black;
    }
}
