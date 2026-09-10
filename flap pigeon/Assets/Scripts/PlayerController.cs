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
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if(touch.phase == TouchPhase.Began)
            {
                rb.linearVelocityY = 5;  
            }
            
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
