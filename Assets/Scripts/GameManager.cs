
using UnityEngine;
using UnityEngine.UI;
using TMPro; //Namesapce for textmeshpro
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Singleton instance
    public static GameManager Instance { get; private set; }

    [Header("Game Stats")]
    public int score = 0;//score is calculated
    public int lives = 3;
    public int enemiesKilled = 0;

    [Header("UI References")]
    public Text scoreText;
    public Text livesText;
    public Text enemiesKilledText;
    public GameObject gameOverPanel;
    //public TMP_Text scoreText;

    private void Awake()
    {
        // Singleton pattern implementation
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Persist across scenes
        }
        else
        {
            Destroy(gameObject); // Destroy duplicate GameManagers
        }
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded; //unsubscribe
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded; //subscribe
    }



    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        RefreshUIReferences(); //refresh ui upon reloading the scene, score and lives

        UpdateUI(); //set up label text

    }

    private void Start()
    {
        //RefreshUIReferences();
        //UpdateUI();

    }

    private void RefreshUIReferences()
    {
        
       scoreText = GameObject.Find("Score")?.GetComponent<Text>(); //scores not scorestext
       livesText = GameObject.Find("Lives")?.GetComponent<Text>();
       enemiesKilledText = GameObject.Find("EnemiesKilled")?.GetComponent<Text>();
       gameOverPanel = GameObject.Find("GameEndPanel");
        if (gameOverPanel != null) //if panel exists
        {
            gameOverPanel.SetActive(false); //make inactive
        }

    }
    public void AddScore(int points)
    {
        score += points;
        Debug.Log($"Score increased by {points}. Total: {score}");
        UpdateUI();

        if (score>1999)
        {
            SceneManager.LoadScene("WinScreen");
        }
    }


    public void LoseLife()
    {
        lives--;
        Debug.Log($"Life lost! Lives remaining: {lives}");
        UpdateUI();

        if (lives <= 0)
        {
            GameOver();
        }
    }

    public void EnemyKilled()
    {
        enemiesKilled++;
        AddScore(100); // 100 points per enemy
        Debug.Log($"Enemy killed! Total enemies defeated: {enemiesKilled}");
    }


    public void CollectiblePickedUp(int value)
    {
        AddScore(value);
        Debug.Log($"Collectible picked up worth {value} points!");
    }

    private void UpdateUI()
    {
        if (scoreText) scoreText.text = "Score: " + score;
        if (livesText) livesText.text = "Lives: " + lives;
        if (enemiesKilledText) enemiesKilledText.text = "Enemies: " + enemiesKilled;
    }

    private void GameOver()
    {
        Debug.Log("GAME OVER!");
        if (gameOverPanel) gameOverPanel.SetActive(true);
        Time.timeScale = 0f; // Pause the game
    }

    public void reloadGame()
    {
        //SceneManager.LoadScene("Delete");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void quitGame()
    {
        Application.Quit();
    }


    public void RestartGame()
    {
        Time.timeScale = 1f;

        // Reset all game state
        score = 0;
        lives = 3;
        enemiesKilled = 0;

         SceneManager.LoadScene(SceneManager.GetActiveScene().name);
       
    }


}
