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
    private bool selected = false;
    private bool revealed = false;
    private SpriteRenderer sprite;
    private Animator animator;
    private ParticleSystem particle;
    private GameController gameController;

    public bool IsSelected() {
        return selected;
    }

    public bool IsReal() {
        return real;
    }

    public void SetDestination(Vector2 coordinates) {
        destination = coordinates;
    }

    public void SetReal(bool flag) {
        real = flag;
    }

    public void SetSpeed(float speed) {
        moveSpeed = speed;
    }

    private void Awake() {
        animator = GetComponent<Animator> ();
        audioSource = GetComponent<AudioSource> ();
        sprite = GetComponentInChildren<SpriteRenderer> ();
        GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
        gameController = gameControllerObject.GetComponent<GameController> ();
    }

    private void Start() {
        transform.position = new Vector2 (Random.Range (-6, 6), Random.Range (-4, 4));
        destination = transform.position;
	}

	private void Update () {
        if (((Vector2)transform.position - destination).sqrMagnitude <= 0.1) {
            if (!gameController.IsGameOver ()) {
                audioSource.Stop ();

                destination = new Vector2 (Random.Range (-6f, 6f), Random.Range (-4f, 4f));
                if (!real) {
                    audioSource.clip = mechanicalClip;
                    audioSource.Play ();
                }
            } else {
                if (!revealed) {
                    animator.SetTrigger ("RevealT");
                    if (!real) {
                        sprite.sprite = fakeMonkey;
                    } else if (selected) {
                        particle = GetComponentInChildren<ParticleSystem> (); // this doesn't work if the particle's parent is disabled
                        particle.Play ();
                    }
                }
                revealed = true;
            }

        }

        transform.position = Vector2.Lerp (transform.position, destination, moveSpeed * Time.deltaTime);
	}

    private void OnMouseDown() {
        if (!gameController.IsGameOver()) {
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
    }
}
