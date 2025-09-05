using UnityEngine;

public class Destruction : MonoBehaviour
{
    public Transform spawnLocation;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Background"))
        {
            if (spawnLocation != null)
            {
                other.transform.position = spawnLocation.position;
            }
            else
            {
                Debug.Log("Not Set");
            }
        }
    }
}
