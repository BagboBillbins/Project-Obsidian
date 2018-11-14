using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkullCheckpoint : MonoBehaviour
{

    [SerializeField]
    private float inactiveScale = 1, activeScale = 1.5f;

    private bool active = false;
    private SpriteRenderer spriteRenderer;
    private AudioSource audioScource;

    // Use this for initialization
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        audioScource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void UpdateScale()
    {
        float scale = inactiveScale;
        if (active)
            scale = activeScale;
        transform.localScale = Vector3.one * scale;
    }
    public void setActive(bool value)
    {
        active = value;
        UpdateScale();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !active)
        {
            Debug.Log("Player entered checkpoint");
            PlayerCharacter player = collision.GetComponent<PlayerCharacter>();
            player.SetCurrentCheck(this);
            audioScource.Play();
        }

    }
}
