using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameWinNew : MonoBehaviour
{
    //Text object to display YOU WIN message
    public TextMeshProUGUI winText;

    //Text object to display ENTER message
    public TextMeshProUGUI restartText;

    private bool hasWon = false;
    public void HideWinMessage()
    {
        //To hide both the texts during the start of the game
        winText.gameObject.SetActive(false);
        hasWon = false;

        restartText.gameObject.SetActive(false);
    }

    //To check if we won
    public void CheckWinCondition()
    {
        GameObject[] bricks = GameObject.FindGameObjectsWithTag("brick");

        //This checks if there are no more bricks left and if the player has not won
        if (bricks.Length == 0 && !hasWon)
        {
            //Setiing the win to true
            hasWon = true;

            //Displays the YOU WIN text here
            winText.gameObject.SetActive(true);
            winText.text = "YOU WIN";

            //The restart text also becomes visible here
            restartText.gameObject.SetActive(true) ;
            
        }
    }
}
