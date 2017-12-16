using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
    public int realMonkeys;
    public GameObject monkey;

    void Start () {
        for (int i = 0; i < 6; i++) {
            Instantiate (monkey);
        }
	}
}
