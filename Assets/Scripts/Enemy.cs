using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    private bool Alive = true;

    private Animator Eneani;
    private SpriteRenderer Enesr;

    public GameObject ignoreBox1;
    public GameObject ignoreBox2;

    private void Awake()
    {
        Eneani = GetComponent<Animator>();
        Enesr = GetComponent<SpriteRenderer>();

        
    }
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Eneani.SetBool("Isdead", true);
            Destroy(gameObject);
        }
    }
}
