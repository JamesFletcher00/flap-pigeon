using UnityEngine;

public class Destruction : MonoBehaviour
{

    [Header("Pipe Recycling")]
    [SerializeField] private float pipeResetX = 15f;
    private float minY =-1f;
    private float maxY = 3f;



    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Pipes"))
        {
            float newY = Random.Range(minY, maxY);
            other.transform.position = new Vector3(pipeResetX, newY, other.transform.position.z);
        }
    }
}
