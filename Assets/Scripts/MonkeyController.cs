 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonkeyController : MonoBehaviour {
	public float moveSpeed;
    public Vector2 destination;
    public GameObject selectionArrow;

	private Rigidbody2D rb;

	void Start() {
        rb = GetComponent<Rigidbody2D> ();

        rb.position = new Vector2 (Random.Range (-6, 6), Random.Range (-4, 4));
        destination = new Vector2 (Random.Range (-6, 6), Random.Range (-4, 4));
	}

	void Update () {
        if ((rb.position - destination).sqrMagnitude <= 0.1) {
            destination = new Vector2 (Random.Range (-6, 6), Random.Range (-4, 4));
            selectionArrow.SetActive(!selectionArrow.activeInHierarchy);
        }
        rb.position = Vector2.Lerp(rb.position, destination, moveSpeed * Time.deltaTime);
	}
}
