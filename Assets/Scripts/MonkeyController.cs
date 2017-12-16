 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonkeyController : MonoBehaviour {
	public float moveSpeed;
    public GameObject selectionArrow;
    public AudioClip selectionClip;
    public AudioClip deselectionClip;
    public AudioClip mechanicalClip;

    private Vector2 destination;
    private AudioSource audioSource;
    private bool real = false;
    private bool selected = false;

    public bool IsSelected() {
        return selected;
    }

    public bool IsReal() {
        return real;
    }

    private void Start() {
        real = Random.Range (0, 2) == 0;

        audioSource = GetComponent<AudioSource> ();

        transform.position = new Vector2 (Random.Range (-6, 6), Random.Range (-4, 4));
        destination = transform.position;
	}

	private void Update () {
        if (((Vector2)transform.position - destination).sqrMagnitude <= 0.1) {
            audioSource.Stop();

            destination = new Vector2 (Random.Range (-6, 6), Random.Range (-4, 4));
            if (!real) {
                audioSource.clip = mechanicalClip;
                audioSource.Play();
            }
        }
        transform.position = Vector2.Lerp(transform.position, destination, moveSpeed * Time.deltaTime);
	}

    private void OnMouseDown() {
        ToggleSelected ();
    }

    private void ToggleSelected() {
        selected = !selected;
        selectionArrow.SetActive(selected);

        if (selected) {
            audioSource.clip = selectionClip;
            audioSource.Play ();
        } else {
            audioSource.clip = deselectionClip;
            audioSource.Play ();
        }

        if (selected && !real) {
            Debug.Log ("Fooled by a fake monkey!");
        }
    }
}
