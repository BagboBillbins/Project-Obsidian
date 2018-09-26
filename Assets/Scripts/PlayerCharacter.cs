using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerCharacter : MonoBehaviour {

    [SerializeField]
    private int lives = 3;

    [SerializeField]
    private string name = "";

    [SerializeField]
    private float jumpHeight = 5, speed = 5;

    [SerializeField]
    private bool hasKey, isOnGround;
    private float thrust;

    private Rigidbody2D rigbody2D;
    

    
	// Use this for initialization
	void Start ()
    {
        rigbody2D = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        rigbody2D.gravityScale = 5;
        //transform.Translate(0, -0.1f, 0); // does not use physics
        //rigbody2D.AddForce(transform.forward * thrust);// uses physics
	}
}
