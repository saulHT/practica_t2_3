using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ninja : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer sr;

    public float velocityX = 10;
    public float jumpFor = 30;

    public GameObject shuriken;
    private Score _game;

    private const int Animation_idle = 0;
    private const int Animation_camina = 1;
    private const int Animation_subir = 2;
    private const int Animation_desliza = 3;
    private const int Animation_saltar = 4;
    private const int Animation_volar = 5;
    private const int Animation_morir = 6;
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        _game = FindObjectOfType<Score>();
    }

    // Update is called once per frame
    void Update()
    {
        //rb.velocity = new Vector2(0, rb.velocity.y);
        //changeAnimation(Animation_idle);

        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.velocity = new Vector2(velocityX, rb.velocity.y);
            sr.flipX = false;
           
            changeAnimation(Animation_camina);
        }
        if (Input.GetKey(KeyCode.LeftArrow) )
        {
            rb.velocity = new Vector2(-velocityX, rb.velocity.y);
            sr.flipX = true;
           
            changeAnimation(Animation_camina);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            changeAnimation(Animation_desliza);
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            
            rb.AddForce(Vector2.up * jumpFor, ForceMode2D.Impulse);
            changeAnimation(Animation_saltar);
        }
        if (Input.GetKeyUp(KeyCode.X))
        {
            var position = new Vector2(transform.position.x, transform.position.y);
            var rotacion = shuriken.transform.rotation;
            Instantiate(shuriken, position, rotacion);
        }
    }
    private void changeAnimation(int animation)
    {
        animator.SetInteger("estado", animation);
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "escalera" && Input.GetKey(KeyCode.UpArrow))
        {
            rb.velocity = new Vector2(0, 6);
            changeAnimation(Animation_subir);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag=="A")
        {
            _game.LoseLifes();
            if (_game.live==0)
            {
                changeAnimation(Animation_morir);
            }
        }
    }

}
