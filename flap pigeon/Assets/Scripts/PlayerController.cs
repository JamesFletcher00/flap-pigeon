using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float flapForce = 5f;
    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            rb.AddForce(transform.up * flapForce);
        }
    }
}
