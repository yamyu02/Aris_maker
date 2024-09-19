using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Attacks : MonoBehaviour
{

    private Transform player;

    private Vector3 tempPos;

    private Animator ATKani;
    private SpriteRenderer asr;
    private Collider2D Attack_col;

    private float movementx;
    

    private string Slash_animation = "Slashing";

    private void Awake()
    {
        ATKani = GetComponent<Animator>();
        asr = GetComponent<SpriteRenderer>();
        Attack_col = asr.GetComponent<Collider2D>();
        Attack_col.enabled = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LateUpdate()
    {
        OffscreenAni();
        Animate(); 
        Directions();
        tempPos.y = player.position.y;
        transform.position = tempPos;
    }


   
    private void Animate()
    {
        movementx = Input.GetAxisRaw("Horizontal");

        if (Input.GetMouseButton(0))
        {
            ATKani.SetBool(Slash_animation, true);
            Attack_col.enabled = true;
            
        }
        else
        {
            ATKani.SetBool(Slash_animation, false);
            Attack_col.enabled = false;
        }
    }


    private void OffscreenAni()
    {
        if (movementx > 0)
        {
            asr.flipX = false;
        }
        else if (movementx < 0)
        {
            asr.flipX = true;
        }
    }
    private void Directions()
    {
        tempPos = transform.position;
        if (movementx > 0)
        {
            tempPos.x = 1 + player.position.x;
        }
        else if (movementx < 0)
        {
            tempPos.x = player.position.x - 1;
        }

    }
}