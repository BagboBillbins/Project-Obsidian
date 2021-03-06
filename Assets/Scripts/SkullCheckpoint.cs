﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkullCheckpoint : MonoBehaviour
{
    private bool active = false;
    private SpriteRenderer spriteRenderer;
    private AudioSource audioScource;
    private Animator anim;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        audioScource = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
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
    public void setActive(bool value)
    {
        active = value;
        if (!active)
            Destroy(gameObject);
    }
}
