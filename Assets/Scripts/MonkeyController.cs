using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonkeyController : MonoBehaviour {
	public float moveSpeed;

	private Rigidbody2D rb;

	void Start() {
		rb = GetComponent<Rigidbody2D> ();
	}

	void Update () {
		rb.MovePosition(new Vector2(transform.position.x - moveSpeed * GetRandomDirection(), transform.position.y - moveSpeed * GetRandomDirection()));
	}

	int GetRandomDirection() {
		switch (Random.Range (0, 3)) {
		case 0:
			return -1;
		case 1:
			return 0;
		default:
			return 1;
		}
	}
}
