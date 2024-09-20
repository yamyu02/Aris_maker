using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float playerHealth = 10;

    [SerializeField]
    private float moveForce = 10f;
    [SerializeField]
    private bool doubleJump = false;
    private float jumpForce = 11f;

    private float movementx;

    [SerializeField]
    private Rigidbody2D mybody;
    private Animator ani;
    private SpriteRenderer sr; 

    private string Walk_animation = "Walk";
    private string Ground_Tag = "Ground"; 
    private bool Grounded = true; 
    private void Awake()
    {
        
        mybody = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();    


    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMoveKeyboard();
        AnimatePlayer();
        PlayerJump();

        if (playerHealth < 1)
        {
            Destroy(gameObject);
        }

    }

    void PlayerMoveKeyboard ()
    {
        movementx = Input.GetAxisRaw("Horizontal");

        transform.position += new Vector3(movementx, 0f, 0f) * Time.deltaTime * moveForce; 
    }
    
    void AnimatePlayer()
    {
        
        if (movementx > 0)
        {
            ani.SetBool(Walk_animation, true);
            sr.flipX = false;
        }
        else if (movementx < 0)
        {
            ani.SetBool(Walk_animation, true);
            sr.flipX = true;
        }
        else
        {
            ani.SetBool(Walk_animation, false);
        }

 
    }
    void PlayerJump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (Grounded)
            {
                Grounded = false;
                mybody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            }
            else if(doubleJump == true)
            {
                doubleJump = false;
                mybody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            }

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(Ground_Tag))
        {
            Grounded = true;
            doubleJump = true;
            if (collision.gameObject.CompareTag("Bullet"))
            {
                playerHealth -= 1;
            }
        }
        else if (collision.gameObject.CompareTag("Bullet"))
        {
            playerHealth -= 1;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            playerHealth -= 1;
        }
    }
} // class
 