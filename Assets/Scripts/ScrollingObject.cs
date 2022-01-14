using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingObject : MonoBehaviour
{
    private Rigidbody2D rb2b;
    // Start is called before the first frame update
    void Start()
    {
        rb2b = GetComponent<Rigidbody2D>();
        rb2b.velocity = new Vector2(GameControl.instance.scrollSpeed, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameControl.instance.gameOver)
        {
            rb2b.velocity = Vector2.zero;
        }
    }
}
