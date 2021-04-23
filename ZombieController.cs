using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieController : MonoBehaviour
{
    private SpriteRenderer sr;
    private Rigidbody2D rb2d;
    private bool tocoLateralB = false;
    private bool tocoLateralA = false;
    public int speed = 1;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        rb2d.velocity = new Vector2(x: speed, rb2d.velocity.y);
        if (tocoLateralB)
        {
            sr.flipX = true;
            rb2d.velocity = new Vector2(x: -speed, rb2d.velocity.y);
        }
        if (tocoLateralA)
        {
            sr.flipX = false;
            rb2d.velocity = new Vector2(x: speed, rb2d.velocity.y);
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        tocoLateralB = false;
        tocoLateralA = false;

        if (other.gameObject.tag == "lateralB")
        {
            tocoLateralB = true;
        }
        if (other.gameObject.tag == "lateralA")
        {
            tocoLateralA = true;
        }
    }
}

