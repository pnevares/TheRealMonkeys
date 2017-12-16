using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
    public GameObject monkey;

	// Use this for initialization
    void Start () {
        for (int i = 0; i < 10; i++) {
            Instantiate (monkey);
        }
	}
}
