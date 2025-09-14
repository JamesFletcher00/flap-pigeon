using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameController : MonoBehaviour
{
    public float moveSpeed = 2f;
    public string tagToMove = "Background";
    public float pipeMoveSpeed = 2f;
    public string pipeTagToMove = "Pipe";




    void Start()
    {

    }

    void Update()
    {
        GameObject[] objects = GameObject.FindGameObjectsWithTag(tagToMove);
        foreach (GameObject obj in objects)
        {
            obj.transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
        }

        GameObject[] pipes = GameObject.FindGameObjectsWithTag(pipeTagToMove);
        foreach (GameObject pip in pipes)
        {
            pip.transform.Translate(Vector2.left * pipeMoveSpeed * Time.deltaTime);
        }
        
    }
    
}
