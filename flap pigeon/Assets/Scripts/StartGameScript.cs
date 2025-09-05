using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class StartGameScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    void OnMouseDown()
    {
        StartGame();
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            StartGame();
        }
    }
    void StartGame()
    {
        SceneManager.LoadScene("GameplayScene");
    }
}
