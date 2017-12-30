using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsButtonController : MonoBehaviour {
    [SerializeField]
    private SpriteRenderer sprite;

    private void OnMouseDown() {
        SceneManager.LoadScene("Credits", LoadSceneMode.Single);
    }

    private void OnMouseEnter() {
        sprite.color = Color.white;
    }

    private void OnMouseExit() {
        sprite.color = Color.black;
    }
}
