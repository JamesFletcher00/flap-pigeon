using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine.UI;
using TMPro;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject tilePrefab;
    [SerializeField] private float scrollSpeed = 5f;
    [Header("Other Scripts")]
    public PlayerController PC;
    public StartGameScript SGS;
    [Header("Game Objects")]
    private GameObject[] activeTiles;
    public SpriteRenderer Bread;
    private float tileWidth;
    private float screenBounds;
    private float pipeMoveSpeed = 6f;
    private string pipeTagToMove = "Pipes";
    [Header("End Game")]
    public bool gameOver = false;
    [Header("UI Elements")]
    public GameObject canvas;
    public TMP_Text UIscore;
    public TMP_Text EndGameScore;
    public TMP_Text HighScore;
    public float Score;
    public float highScore;
    

   void Start()
    {
        canvas.SetActive(false);
        Bread.GetComponent<SpriteRenderer>();
        UIscore.GetComponent<TextMeshProUGUI>();
        EndGameScore.GetComponent<TextMeshProUGUI>();
        HighScore.GetComponent<TextMeshProUGUI>();
        
        // Calculate screen boundaries
        Camera cam = Camera.main;
        screenBounds = cam.orthographicSize * cam.aspect;
        
        // Create first tile and get its size after instantiation
        activeTiles = new GameObject[6];
        activeTiles[0] = Instantiate(tilePrefab, new Vector2(-10, -1), Quaternion.identity);
        
        // Get the width from the instantiated tile
        tileWidth = activeTiles[0].GetComponent<SpriteRenderer>().bounds.size.x;
        
        // Create remaining tiles immediately to the right
        activeTiles[1] = Instantiate(tilePrefab, new Vector2((tileWidth -10), -1), Quaternion.identity);
        activeTiles[2] = Instantiate(tilePrefab, new Vector2((tileWidth * 2) - 10, -1), Quaternion.identity);
        activeTiles[3] = Instantiate(tilePrefab, new Vector2((tileWidth * 3) -10, -1), Quaternion.identity);
        activeTiles[4] = Instantiate(tilePrefab, new Vector2((tileWidth * 4) -10, -1), Quaternion.identity);
        activeTiles[5] = Instantiate(tilePrefab, new Vector2((tileWidth * 5) -10, -1), Quaternion.identity);


    }

    void Update()
    {
        // Move all tiles left
        for (int i = 0; i < activeTiles.Length; i++)
        {
            activeTiles[i].transform.Translate(Vector2.left * scrollSpeed * Time.deltaTime);
        }
        
        // Check each tile to see if it needs recycling
        for (int i = 0; i < activeTiles.Length; i++)
        {
            // If any tile is completely off-screen to the left
            if (activeTiles[i].transform.position.x < -screenBounds - tileWidth)
            {
                // Find which tile is farthest to the right
                GameObject rightmostTile = activeTiles[0];
                for (int j = 1; j < activeTiles.Length; j++)
                {
                    if (activeTiles[j].transform.position.x > rightmostTile.transform.position.x)
                    {
                        rightmostTile = activeTiles[j];
                    }
                }
                
                // Move the off-screen tile to the right of the rightmost tile
                float newX = rightmostTile.transform.position.x + tileWidth;
                activeTiles[i].transform.position = new Vector2(newX, -1);
            }
        }

        GameObject[] pipes = GameObject.FindGameObjectsWithTag(pipeTagToMove);
        foreach (GameObject pip in pipes)
        {
            pip.transform.Translate(Vector2.left * pipeMoveSpeed * Time.deltaTime);
        }
        
        if(gameOver)
        {
            GameOver();
        }

        if(Time.timeScale == 0 && Input.GetKeyDown(KeyCode.Space))
        {
            SGS.StartGame();
        }

        UIscore.text = "" + Score;
    }
    void GameOver()
    {
        Time.timeScale = 0;
        EndGameScore.text = "" + Score;
        HighScore.text = "" + highScore;
        canvas.SetActive(true);
        if(Score > highScore)
        {
            highScore = Score;
        }

    }
    public void StartGame()
    {
        Time.timeScale = 1;
        gameOver = false;
        canvas.SetActive(false);
    }
    public void HideBread()
    {
        Score++;
        Bread.sortingOrder = 0;
    }
    public void EnableBread()
    {
        Bread.sortingOrder = 2;
    }
    
}
