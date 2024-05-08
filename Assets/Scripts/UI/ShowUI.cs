using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class ShowUI : MonoBehaviour
{
    public FirstPersonController FPS;
    public EnemyCounter enemyCounter;
    public TextMeshProUGUI enemyStatusText;

    private bool isTextShowing;

    private void Start()
    {
        isTextShowing = false;
    }

    private void Update()
    {
        if(FPS.hasPassword && enemyCounter.enemiesAlive.Length != 0 && !isTextShowing)
        {
            enemyStatusText.text = "TO WIN, KILL BOTH THE ENEMIES";
            isTextShowing = true;
            StartCoroutine(TextDelay(4f));
        }

        else if(!FPS.hasPassword) 
        {
            enemyStatusText.text = "";
        }

        if(FPS.hasPassword && enemyCounter.enemiesAlive.Length == 0)
        {
            enemyStatusText.text = "Congratulation\nYou won!";
        }

        if(FPS.health <= 0)
        {
            enemyStatusText.text = "You Lost";
        }
    }

    private IEnumerator TextDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        enemyStatusText.text = "";
    }
}
