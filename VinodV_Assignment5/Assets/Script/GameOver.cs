using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public TextMeshProUGUI gameOverText;

    private bool isGameOver = false;

    public void HideGameOver()
    {
        gameOverText.gameObject.SetActive(false);
        isGameOver = false;
    }
    public void ShowGameOver()

    {
        if (!isGameOver)
        {
            isGameOver = true;
            gameOverText.gameObject.SetActive(true);
            gameOverText.text = "GAME OVER";
        }
    }
}
