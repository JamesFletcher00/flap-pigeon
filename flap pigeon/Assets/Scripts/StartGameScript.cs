using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class StartGameScript : MonoBehaviour
{
    void OnMouseDown()
    {
        StartGame();
    }
    public void StartGame()
    {
        SceneManager.LoadScene("GameplayScene");
        Time.timeScale = 1;
    }
}
