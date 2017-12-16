﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitButtonController : MonoBehaviour {
    private SpriteRenderer sprite;

    private void Start() {
        sprite = GetComponent<SpriteRenderer> ();
    }

    private void OnMouseDown() {
        Application.Quit ();
    }

    private void OnMouseEnter() {
        sprite.color = Color.white;
    }

    private void OnMouseExit() {
        sprite.color = Color.black;
    }
}