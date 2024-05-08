using TMPro;
using UnityEngine;

public class SaveGame : MonoBehaviour
{
    public Transform player;
    public Gun gun;
    public Player player_data;

    public GameObject pauseMenuPanel;
    public TextMeshProUGUI pauseText;


    private void Update()
    {
        // If menu is hidden
        if(!pauseMenuPanel.activeSelf)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                pauseMenuPanel.SetActive(true);
                pauseText.text = "Game Paused";

                // Pause the game
                Time.timeScale = 0f;
            }
        }

        // If menu is visible
        else if (pauseMenuPanel.activeSelf)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                pauseMenuPanel.SetActive(false);

                // resume game
                Time.timeScale = 1f;
            }
        }

        if(player_data.currentHealth <= 0)
        {
            pauseText.text = "  Player Died";
        }

    }


    public void SavePlayerData()
    {
        // Saving current and max ammo
        PlayerPrefs.SetInt("CurrentAmmo", gun.currentAmmo);
        PlayerPrefs.SetInt("MaxAmmo", gun.maxAmmo);

        // Serialize player position data into JSON string
        string playerPositionJson = JsonUtility.ToJson(player.position);
        // Save serialized position data to PlayerPrefs
        PlayerPrefs.SetString("PlayerPosition", playerPositionJson);

        // Saving current score
        PlayerPrefs.SetInt("CurrentScore", GameManager.Instance.score);

        // Saving Health
        PlayerPrefs.SetInt("CurrentHealth", player_data.currentHealth);
    }

    public void LoadPlayerData()
    {
        // Loading saved current and max ammo
        gun.currentAmmo = PlayerPrefs.GetInt("CurrentAmmo", 0);
        gun.maxAmmo = PlayerPrefs.GetInt("MaxAmmo", 0);

        // Check if player position data exists in PlayerPrefs
        if (PlayerPrefs.HasKey("PlayerPosition"))
        {
            // Retrieve serialized position data from PlayerPrefs
            string playerPositionJson = PlayerPrefs.GetString("PlayerPosition");

            // Deserialize position data from JSON string
            Vector3 playerPosition = JsonUtility.FromJson<Vector3>(playerPositionJson);

            // Set the player's position
            player.position = playerPosition;
        }

        // Loading saved score
        GameManager.Instance.score = PlayerPrefs.GetInt("CurrentScore", 0);

        // Loading saved health
        player_data.currentHealth = PlayerPrefs.GetInt("CurrentHealth", 0);
    }
}
