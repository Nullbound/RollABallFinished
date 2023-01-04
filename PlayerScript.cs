using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    //Variables 

    public float speed = 5f;
    public float jumpSpeed = 8f;
    private float direction = 0f;
    private Rigidbody2D player;
    private bool facingRight;
    public Animator myAnimator;

    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask groundLayer;
    private bool isTouchingGround;

    public bool isAlive;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody2D> ();
        myAnimator = GetComponent<Animator> ();
        facingRight = true;
        isAlive = true;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");

        if(isAlive)
        {
            Flip(horizontal);
            Movement(horizontal);
        }
        else
        {
            return;
        }

        isTouchingGround = Physics2D.OverlapCircle(groundCheck.position , groundCheckRadius , groundLayer);
        direction = Input.GetAxis("Horizontal"); 
    }
    //Function Definitions

    void Flip(float horizontal)
    {
        if (horizontal < 0 && facingRight || horizontal > 0 && !facingRight)
        {
            facingRight = !facingRight; //resets the bool to the opposite value
            Vector2 theScale = transform.localScale;  //creating a vector 2 and storing the local scale values
            theScale.x *= -1;     //take the x component of theScale and multiply it by -1
            transform.localScale = theScale;    //feeds the resulting value from the multiplication into theScale
        }
    }

    void Movement(float horizontal)
    {
        if(direction > 0f)
        {
            player.velocity = new Vector2(direction * speed , player.velocity.y);
        }
        else if(direction < 0f)
        {
            player.velocity = new Vector2(direction * speed , player.velocity.y);
        }
        else
        {
            player.velocity = new Vector2(0, player.velocity.y);
        }

        if(Input.GetButtonDown("Jump") && isTouchingGround)
        {
            player.velocity = new Vector2(player.velocity.x , jumpSpeed);
            myAnimator.SetBool("jumping" , true);
        }
        myAnimator.SetFloat("speed" , Mathf.Abs (horizontal));
    }

    void OnCollisionEnter2D(Collision2D target)
    {
        if(target.gameObject.tag == "Ground")
        {
            myAnimator.SetBool("jumping" , false);
        }
        if(target.gameObject.tag == "deadly")
        {
            isAlive = false;
            myAnimator.SetBool("dead" , true);
        }
    }
}

