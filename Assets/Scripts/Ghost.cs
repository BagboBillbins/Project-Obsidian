using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour {

    private SpriteRenderer spriteRenderer;
    private Animator anim;
    private AudioSource audioSource;
    [SerializeField]
    private AudioClip appear, disappear;

    // Use this for initialization
    void Start ()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
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
        }
        else
            Debug.Log("Something has hit a hazard");
        //Destroy(spriteRenderer);

    }
}
