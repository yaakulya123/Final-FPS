using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Singleton Instance
    public static GameManager Instance { get; private set; }

    public int score;
    public int highestScore;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highestScoreText;

    public int enemyCount;
    public GameObject enemyPrefab; // Reference to the enemy prefab
    public Transform[] spawnPoints; // Array of spawn points for enemies

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        LoadBestScore(); // Load the highest score from PlayerPrefs
    }

    private void Update()
    {
        scoreText.text = "Score: " + score.ToString();
        highestScoreText.text = "Highest Score: " + highestScore.ToString();

        // Check if the current score is greater than the highest score
        if (score > highestScore)
        {
            highestScore = score;
            SaveBestScore(); // Save the new highest score
        }
    }

    public void AddScore()
    {
        score += 10;
    }

    public void UpdateEnemyCount(int enemiesAlive)
    {
        enemyCount += enemiesAlive;

        // Spawn new enemies if count drops to zero
        if (enemyCount == 0)
        {
            SpawnNewEnemies();
        }
    }

    private void SpawnNewEnemies()
    {
        // Determine how many enemies need to be spawned
        int enemiesToSpawn = 2;

        for (int i = 0; i <= enemiesToSpawn; i++)
        {
            int randomIndex = Random.Range(0, spawnPoints.Length);
            Instantiate(enemyPrefab, spawnPoints[randomIndex].position, Quaternion.identity);
        }
    }

    private void SaveBestScore()
    {
        PlayerPrefs.SetInt("HighestScore", highestScore);
        PlayerPrefs.Save();
    }

    private void LoadBestScore()
    {
        highestScore = PlayerPrefs.GetInt("HighestScore", 0);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
