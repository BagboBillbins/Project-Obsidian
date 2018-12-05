using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour {

    private SpriteRenderer spriteRenderer;
    private Animator anim;
    private AudioSource audioSource;
    private BoxCollider2D boxCollider2D;
    [SerializeField]
    private AudioClip appear, disappear;

    // Use this for initialization
    void Start ()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        boxCollider2D = GetComponent<BoxCollider2D>();
    }
	void FixedUpdate ()
    {
        anim.SetBool("Appear", true);
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerCharacter player = collision.GetComponent<PlayerCharacter>();
            audioSource.clip = disappear;
            audioSource.Play();
            anim.SetBool("Vanish", true);
            boxCollider2D.enabled = false;
        }
    }
}
