using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogController : MonoBehaviour
{
    private SpriteRenderer sr;
    private Animator _animator;
    private Rigidbody2D rb2d;
    private int puntaje = 0;

    private bool puedoSaltar = false;
    private int saltos = 0;
    public float upSpeed = 20;
    public float speed = 10;
    private int morir = 0;

    public GameObject rightBall;
    public GameObject leftBall;


    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        //CREAR BALL

        if (Input.GetKeyDown(KeyCode.A))
        {
            if (!sr.flipX)
            {
                var position = new Vector2(transform.position.x + 1.5f, transform.position.y -0.5f);
                Instantiate(rightBall, position, rightBall.transform.rotation);
            }
            else
            {
                var position = new Vector2(transform.position.x  - 2.5f, transform.position.y - 0.5f);
                Instantiate(leftBall, position, leftBall.transform.rotation);
            }

        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            sr.flipX = false;
            setRunAnimation();
            rb2d.velocity = new Vector2(x: 5, rb2d.velocity.y);
        }
        else
        {
            rb2d.velocity = new Vector2(0, rb2d.velocity.y); 
            setIdleAnimation();
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            sr.flipX = true;
            setRunAnimation();
            rb2d.velocity = new Vector2(x: -5, rb2d.velocity.y);
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) && puedoSaltar)
        {
            setJumpAnimation();
            float upSpeed = 35;
            rb2d.velocity = Vector2.up * upSpeed;
            saltos++;
        }

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        puedoSaltar = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "coin")
        {
            puntaje += 1;
            Debug.Log("PUNTAJE: " + puntaje);
            Destroy(other.gameObject);
        }
    }


    private void setIdleAnimation()
    {
        _animator.SetInteger("Estado", 0);
    }
    private void setRunAnimation()
    {
        _animator.SetInteger("Estado", 1);
    }
    private void setJumpAnimation()
    {
        _animator.SetInteger("Estado", 2);
    }
    private void setDeadAnimation()
    {
        _animator.SetInteger("Estado", 3);
    }
}
