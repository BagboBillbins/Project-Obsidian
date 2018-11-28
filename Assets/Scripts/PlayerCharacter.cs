using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class PlayerCharacter : MonoBehaviour {

    [SerializeField]
    private float deadColliderSize = 1;
    [SerializeField]
    private int lives = 3;
    [SerializeField]
    private string name = "";
    [SerializeField]
    private float jumpForce = 5, speed = 5;
    [SerializeField]
    private ContactFilter2D groundContactFilter;
    [SerializeField]
    private Collider2D groundDetectTrig;
    [SerializeField]
    private CapsuleCollider2D playerGroundCollider;
    [SerializeField]
    private PhysicsMaterial2D playerMovePhys, playerStopPhys;

    private float horzInput;
    private float jump;
    private float maxSpeed = 10f;
    private bool facingRight;
    private bool onGround;
    private float aliveColliderSize;
    private bool isDead;
   // private bool canMove;

    private Collider2D[] groundHitDetector = new Collider2D[16];
    private Rigidbody2D rb2d;
    private Animator anim;
    private AudioSource audioSource;
    private SkullCheckpoint currentCheck;

    // Use this for initialization
    void Start ()
    {
        aliveColliderSize = playerGroundCollider.size.y;
        //have to initialize rigidbody or will throw null exception
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }
	// Update is called once per frame
	void Update ()
    {
        //rb2d.gravityScale = 5;
        UpdateOnGround();
        UpdateHorzInput();
        JumpInputHandler();


        //transform.Translate(0, -0.1f, 0); // does not use physics
        //rigbody2D.AddForce(transform.forward * thrust);// uses physics
    }
    void FixedUpdate()
    {
        anim.SetFloat("Speed", Mathf.Abs(horzInput));
        anim.SetBool("Ground", onGround);
        UpdatePhysMat();
        Move();
        if(!isDead)
        {
            if (horzInput < 0 && !facingRight)
                Flip();
            else if (horzInput > 0 && facingRight)
                Flip();
        }
        
        CheckRespawn();
        
    }
    
    private void UpdateHorzInput()
    {
        horzInput = Input.GetAxisRaw("Horizontal"); //raw ignores unity's smoothing filter which makes movement more responsive
    }

    private void JumpInputHandler()
    {
        if (Input.GetButtonDown("Jump") && onGround)
            rb2d.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);//Impulse adds immediate action while force is not

    }
    private void Move()
    {
        
        if(!isDead)
        {
            rb2d.AddForce(Vector2.right * horzInput * speed);
            Vector2 clampedVelocity = rb2d.velocity;//set clamp for velocity
            clampedVelocity.x = Mathf.Clamp(rb2d.velocity.x, -maxSpeed, maxSpeed);//clamp the max speed on the x axis
            rb2d.velocity = clampedVelocity;
        }        
    }
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
    private void UpdatePhysMat()
    {
        if (Mathf.Abs(horzInput) > 0)
            playerGroundCollider.sharedMaterial = playerMovePhys;

        else
            playerGroundCollider.sharedMaterial = playerStopPhys;
    }
    private void UpdateOnGround()
    {
        onGround = groundDetectTrig.OverlapCollider(groundContactFilter, groundHitDetector) > 0;
        //Debug.Log("Grounded: " + onGround);

    }

    public void Dead()
    {
        playerGroundCollider.size = new Vector2(playerGroundCollider.size.x, deadColliderSize);
        isDead = true;
        audioSource.Play();
        anim.SetBool("Dead", isDead);
        // rb2d.velocity = Vector2.zero;
    }
    public void CheckRespawn()
    {
        if (isDead && Input.GetButtonDown("Respawn"))
            Respawn();
    }
  
    public void Respawn()
    {
        if (currentCheck == null)
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);//reload current scene on death
        else
        {
            rb2d.velocity = Vector2.zero;
            transform.position = currentCheck.transform.position;
        }
        isDead = false;
        playerGroundCollider.size = new Vector2(playerGroundCollider.size.x, aliveColliderSize);
        anim.SetBool("Dead", isDead);
    }
    public void SetCurrentCheck(SkullCheckpoint newCurrentCheck)
    {
        if (currentCheck != null)
            currentCheck.setActive(false);

        currentCheck = newCurrentCheck;
        currentCheck.setActive(true);

    }

}
