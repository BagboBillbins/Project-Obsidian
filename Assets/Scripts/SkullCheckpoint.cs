using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkullCheckpoint : MonoBehaviour
{

    private bool active = false;
    private SpriteRenderer spriteRenderer;
    private AudioSource audioScource;
    private Animator anim;

    // Use this for initialization
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        audioScource = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void setActive(bool value)
    {
        active = value;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !active)
        {
            Debug.Log("Player entered checkpoint");
            PlayerCharacter player = collision.GetComponent<PlayerCharacter>();
            player.SetCurrentCheck(this);
            anim.SetBool("Dead", true);
            anim.SetBool("Activated", true);
            audioScource.Play();

        }

    }
}
