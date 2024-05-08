using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject instructionsPanel;
    public string gameSceneName;

    private int nextCount;

    public TextMeshProUGUI instructionsText;

    private void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void StartGame()
    {
        SceneManager.LoadScene(gameSceneName);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ShowInstructions()
    {
        instructionsPanel.SetActive(true);
    }

    public void HideInstructions()
    {
        instructionsPanel.SetActive(false);
    }

    public void ShowNextInstruction()
    {
        nextCount++;

        if (nextCount == 0)
        {
            instructionsText.text =

                "<color=\"white\"><b>\t\t\t\t    <u>Player Controls</u></b>\r</color>\r\n\r\n<color=\"lightblue\"><b><u>Movement:\r</b></u>\r</color>\r\n\r\nUse the  <b><color=\"orange\">WASD</color></b> keys to move the player and hold <b><color=\"orange\">Shift</color></b> key to run.\r\n\r\nUse the  <b><color=\"orange\">Space</color></b> key to jump.\r\n\r\n<b><color=\"lightblue\"><u>Interaction Controls: </u></color></b>\r\n\r\nHold <b><color=\"orange\">E</color></b> key to intereact with the password manual.\r\n\r\nUse <b><color=\"orange\">Left mouse button</color></b> to fire. \r\n\r\nPress <b><color=\"orange\">1 </color></b>and <b><color=\"orange\">2 </color></b> keys to switch between weapons. \r\n\r\nPress <b><color=\"orange\">R</color></b> key to reload.\r\n\r\n";
        }

        else if (nextCount == 1)
        {
            instructionsText.text =

                "<color=\"white\"><b>\t\t\t\t\t<u>Objectives</u></b>\r</color>\r\n\r\n<color=\"lightblue\"><b><u>1) Collect Password Key:\r</b></u>\r</color>\r\n\r\nFollow the arrow that is appearing in front of the player.\n\nArrow guides the player to the location where the <b><color=\"orange\">Password Key</color></b> is located.\n\n<b><color=\"orange\">Collect the key</color></b> by touching it.\r\n\r\nAfter collecting the <b><color=\"orange\">Password Key</color></b>, the arrow will guide the player to the area where they password is to be entered.";
        }

        else if (nextCount == 2)
        {
            instructionsText.text =

                "<color=\"white\"><b>\t\t\t\t\t<u>Objectives</u></b>\r</color>\r\n\r\n<color=\"lightblue\"><b><u>2) Enter Password:\r</b></u>\r</color>\r\n\r\nAfter collecting the key, the arrow now will guide the player to the location where the key will be entered.\n\nWhen near the key password manual Hold <b><color=\"orange\">E Key</color></b> to enter the password.\n\nEntering the key will open the doors to the main building.\n    \r\n\r\n <color=\"lightblue\"><b><u>3) Eliminate All Enemies:\r</b></u>\r</color>\n\n Look for enemies in the area and eliminate all of them";
        }

        else if (nextCount == 3)
        {
            instructionsText.text =

                "<color=\"white\"><b>\t\t\t\t\t  <u>Tips</u></b>\r</color>\r\n\r\n<color=\"lightblue\"><b><u>1) Health Box:\r</b></u>\r</color>\r\n\r\nCollect health boxes that are scattered around the map to increase health of player.\n\n <color=\"lightblue\"><b><u>2)Ammo Box:\r</b></u>\r</color>\n\nCollect ammo boxes that are scattered around the map to increase bullets.";
        }

        else if(nextCount >= 4)
        {
            nextCount = 0;
            instructionsText.text =

                "<color=\"white\"><b>\t\t\t\t    <u>Player Controls</u></b>\r</color>\r\n\r\n<color=\"lightblue\"><b><u>Movement:\r</b></u>\r</color>\r\n\r\nUse the  <b><color=\"orange\">WASD</color></b> keys to move the player and hold <b><color=\"orange\">Shift</color></b> key to run.\r\n\r\nUse the  <b><color=\"orange\">Space</color></b> key to jump.\r\n\r\n<b><color=\"lightblue\"><u>Interaction Controls: </u></color></b>\r\n\r\nHold <b><color=\"orange\">E</color></b> key to intereact with the password manual.\r\n\r\nUse <b><color=\"orange\">Left mouse button</color></b> to fire. \r\n\r\nPress <b><color=\"orange\">1 </color></b>and <b><color=\"orange\">2 </color></b> keys to switch between weapons. \r\n\r\nPress <b><color=\"orange\">R</color></b> key to reload.\r\n\r\n";
        }

       
    }


}
