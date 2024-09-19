using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    private bool Alive = true;

    private Animator Eneani;
    private SpriteRenderer Enesr;
    private Collider2D Enemy_col;

    

    private void Awake()
    {
        Eneani = GetComponent<Animator>();
        Enesr = GetComponent<SpriteRenderer>();
        Enemy_col = GetComponent<Collider2D>();
        
    }
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Attack_Slash"))
        {
            Eneani.SetBool("Isdead", true);
            Enemy_col.enabled = false;
        }
    }
}
