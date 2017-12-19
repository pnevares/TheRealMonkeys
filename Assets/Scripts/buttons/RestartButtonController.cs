using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartButtonController : MonoBehaviour {
    [SerializeField]
    private SpriteRenderer sprite;
    private GameController gameController;

    private void Start() {
        GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
        gameController = gameControllerObject.GetComponent<GameController> ();
    }

    private void OnMouseDown() {
        gameController.Restart ();
    }

    private void OnMouseEnter() {
        sprite.color = Color.white;
    }

    private void OnMouseExit() {
        sprite.color = Color.black;
    }
}
