using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class EnemyCounter : MonoBehaviour
{
    public FirstPersonController FPS;

    [Header("UI")]
    public GameObject gameOverPanel;
    public GameObject crosshair;
    public TextMeshProUGUI weaponTypeText;
    public TextMeshProUGUI bulletText;

    public GameObject[] enemiesAlive;

    private void Update()
    {
        enemiesAlive = GameObject.FindGameObjectsWithTag("Enemy");

        if(enemiesAlive.Length == 0 || FPS.health <= 0)
        {
            gameOverPanel.SetActive(true);

            // Disable UI

            crosshair.SetActive(false);
            weaponTypeText.text = "";
            bulletText.text = "";
        }

       // Debug.Log(enemiesAlive.Length);
    }
}
