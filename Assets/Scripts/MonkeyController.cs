 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonkeyController : MonoBehaviour {
	public float moveSpeed;
    public GameObject selectionArrow;
    public Sprite fakeMonkey;
    public AudioClip selectionClip;
    public AudioClip deselectionClip;
    public AudioClip mechanicalClip;

    private Vector2 destination;
    private AudioSource audioSource;
    private bool real = false;
    private bool paused = false;
    private bool selected = false;
    private SpriteRenderer sprite;

    public bool IsSelected() {
        return selected;
    }

    public bool IsReal() {
        return real;
    }

    public void Pause() {
        paused = true;
    }

    public void SetDestination(Vector2 coordinates) {
        destination = coordinates;
    }

    private void Start() {
        real = Random.Range (0, 2) == 0;

        audioSource = GetComponent<AudioSource> ();
        sprite = GetComponentInChildren<SpriteRenderer> ();

        transform.position = new Vector2 (Random.Range (-6, 6), Random.Range (-4, 4));
        destination = transform.position;
	}

	private void Update () {
        if (!paused) {
            if (((Vector2)transform.position - destination).sqrMagnitude <= 0.1) {
                audioSource.Stop ();

                destination = new Vector2 (Random.Range (-6, 6), Random.Range (-4, 4));
                if (!real) {
                    audioSource.clip = mechanicalClip;
                    audioSource.Play ();
                }
            }
        }

        if (paused && ((Vector2)transform.position - destination).sqrMagnitude <= 0.01) {
            if (!real) {
                sprite.sprite = fakeMonkey;
            }
            destination = Vector2.zero;
        }

        if (destination != Vector2.zero) {
            transform.position = Vector2.Lerp (transform.position, destination, moveSpeed * Time.deltaTime);
        }
	}

    private void OnMouseDown() {
        if (!paused) {
            ToggleSelected ();
        }
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

//        if (selected && !real) {
//            Debug.Log ("Fooled by a fake monkey!");
//        }
    }
}
