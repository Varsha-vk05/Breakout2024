using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameWin : MonoBehaviour
{
    public TextMeshProUGUI winText;

    private bool hasWon = false;

     public void HideWinMessage()
    {
        winText.gameObject.SetActive(false);
        hasWon = false;
    }

    
    public void CheckWinCondition()
    {
        GameObject[] bricks = GameObject.FindGameObjectsWithTag("brick");
        if (bricks.Length==0&& !hasWon)
        {
            hasWon = true;
            winText.gameObject.SetActive(true);
            winText.text = "YOU WIN";
        }
    }
}
