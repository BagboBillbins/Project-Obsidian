using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour {

    private SpriteRenderer spriteRenderer;
    private Animator anim;

	// Use this for initialization
	void Start ()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
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
            anim.SetBool("Vanish", true);
        }
        else
            Debug.Log("Something has hit a hazard");
        //Destroy(spriteRenderer);

    }
}
