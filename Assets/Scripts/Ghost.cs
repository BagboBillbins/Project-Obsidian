using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Ghost : MonoBehaviour {

    [SerializeField]
    private AudioClip appear, disappear;
    [SerializeField]
    private CinemachineVirtualCamera vcam1, vcam2;

    private SpriteRenderer spriteRenderer;
    private Animator anim;
    private AudioSource audioSource;
    private BoxCollider2D boxCollider2D;
    private CinemachineVirtualCamera cinemachine;
    

    // Use this for initialization
    void Start ()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        boxCollider2D = GetComponent<BoxCollider2D>();
        cinemachine = vcam2;
        vcam2.MoveToTopOfPrioritySubqueue();
        anim.SetBool("Appear", true);

    }
    private void Update()
    {

        if (this.anim.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {

            cinemachine = vcam1;
            vcam1.MoveToTopOfPrioritySubqueue();
        }
        
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
