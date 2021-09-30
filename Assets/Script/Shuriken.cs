using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shuriken : MonoBehaviour
{
    private float velocity = 10;
    private Score _game;

    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 3);
        _game = FindObjectOfType<Score>();
    }

    // Update is called once per frame
    void Update()
    {
        
            rb.velocity = new Vector2(velocity, rb.velocity.y);
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag=="A")
        {
            Destroy(collision.gameObject);
            _game.PlusScorte(10);
        }
    }
}
