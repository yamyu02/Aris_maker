using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Attacks: MonoBehaviour
{

    private Transform player;

    private Vector3 tempPos;

    private Animator ATKani;
    private SpriteRenderer asr;

    private float movementx;
    private int counter = 1;
    private bool attacking = false; 
    
    private string Slash_animation = "Slashing";

    private void Awake()
    {
        ATKani = GetComponent<Animator>();
        asr = GetComponent<SpriteRenderer>();
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
        Count();
        Animate();
        Directions();
    }

    private void Count()
    {
        counter += 1;
    }


    private void Animate()
    {
        movementx = Input.GetAxisRaw("Horizontal");

        if (counter == 50)
        {
            attacking = true;
            ATKani.SetBool(Slash_animation, true);
            counter = 1;
            if (movementx > 0)
            { 
                asr.flipX = false;
            }
            else if (movementx < 0)
            {
                asr.flipX = true;
            }
        }
        else
        {
            ATKani.SetBool(Slash_animation, false);
        }
    }
    private void Directions()
    {
        tempPos = transform.position;
        if (movementx > 0 && attacking == true)
        {
            tempPos.x = 1 + player.position.x;
        }
        else if (movementx < 0 && attacking == true)
        {
            tempPos.x = player.position.x - 1;
        }
        else
        {
            
            attacking = false;
        }

        tempPos.y = player.position.y;
        transform.position = tempPos;

    }




}