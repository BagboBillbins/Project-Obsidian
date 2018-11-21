using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameSkull : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision)

    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player entered hazard");
            PlayerCharacter player = collision.GetComponent<PlayerCharacter>();
            player.Dead();
            player.CheckRespawn(); //respawn player at checkpoint

        }
        else
            Debug.Log("Something has hit a hazard");


    }
}
