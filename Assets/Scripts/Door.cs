using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{

    [SerializeField]
    private string sceneToLoad;
    private bool playerInTrig;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInTrig = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInTrig = false;
        }
    }

    private void Update()
    {
        if (Input.GetButtonDown("Activate") && playerInTrig)
        {
            audioSource.Play();
            Debug.Log("Player activated door");
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}

