using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    public int player_number;
    public float upForce = 200.0f;

    private bool isDead = false;
    private bool isDead1 = false;
    private Rigidbody2D rb2d;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isDead)
        {
            if (Input.GetKeyDown(KeyCode.W) && player_number == 0)
            {
                rb2d.velocity = Vector2.zero;
                rb2d.AddForce(new Vector2(0, upForce));
                anim.SetTrigger("Flap");
            }
        }
        
        if (!isDead1)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow) && player_number == 1) 
            {
                rb2d.velocity = Vector2.zero;
                rb2d.AddForce(new Vector2(0, upForce));
                anim.SetTrigger("Flap");
            }
        }
    }

    void OnCollisionEnter2D()
    {
        if (!isDead && player_number == 0)
        {
            rb2d.velocity = Vector2.zero;
            isDead = true;
            anim.SetTrigger("Die");
            GameControl.instance.BirdDied();
        }

        if (!isDead1 && player_number == 1)
        {
            rb2d.velocity = Vector2.zero;
            isDead1 = true;
            anim.SetTrigger("Die");
            GameControl.instance.BirdDied();
        }
    }
}
