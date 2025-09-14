using UnityEngine;

public class Destruction : MonoBehaviour
{
    [Header("Background Recycling")]
    public Transform backgroundSpawnLocation;

    [Header("Pipe Recycling")]
    public float pipeResetX = 10f;
    public float minY =-1f;
    public float maxY = 3f;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Background"))
        {
            if (backgroundSpawnLocation != null)
            {
                other.transform.position = backgroundSpawnLocation.position;
            }
            else
            {
                Debug.Log("Not Set");
            }
        }
        if (other.CompareTag("Pipe"))
        {
            float newY = Random.Range(minY, maxY);
            other.transform.position = new Vector3(pipeResetX, newY, other.transform.position.z);
        }
    }
}
