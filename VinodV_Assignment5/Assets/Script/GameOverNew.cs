using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOverNew : MonoBehaviour
{
    //Text object to display the game over message
    public TextMeshProUGUI gameOverText;

    //Text object to display the RESTART message
    public TextMeshProUGUI restartText;

    private bool isGameOver = false;

    public void HideGameOver()
    {
        //This is to hide the GAME OVER and RESTART texts at the start 
        gameOverText.gameObject.SetActive(false);
        isGameOver = false;

        restartText.gameObject.SetActive(false);
    }

    //This is to show the gameover message 
    public void ShowGameOver()

    {
        //Checking if the game is not over
        if (!isGameOver)
        {
            //Setting the game over to true 
            isGameOver = true;

            //This will display the GAME OVER text 
            gameOverText.gameObject.SetActive(true);
            gameOverText.text = "GAME OVER";


            //This will display the RESTART text
            restartText.gameObject.SetActive(true);
        }
    }
}
