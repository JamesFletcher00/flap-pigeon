using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;
    public GameController GC;
    public Destruction destruction;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            rb.linearVelocityY = 5;
        }
        if(Input.GetKey(KeyCode.P))
        {
            GC.StartGame();
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Pipe"))
        {
            GC.gameOver = true;
        }
        if(collision.CompareTag("Bread"))
        {
            GC.HideBread();

        }
    }
}
