using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEditor.PlayerSettings;

// Cool comment
public class Ball : MonoBehaviour
{
    //Position when the ball triggers game over
    public float position = -5f;

    //Maximum velocity of the ball
    public float Maximumvelocity = 15f;

    //Rigidbody of the ball
    Rigidbody2D rigid;

    private Player player;

    int score = 0;
    public TextMeshProUGUI Scoretext;

    //Referencing to the GameOver script
    private GameOverNew gameover;
    private bool isGameOver = false;

    //Referencing to the GameWin script
    private GameWinNew gameWin;
    private bool hasWon = false;




    void Start()
    {
        //To attach rigid body component to the ball
        rigid = GetComponent<Rigidbody2D>();

        player=FindObjectOfType<Player>();

        gameover = FindAnyObjectByType<GameOverNew>();
        gameWin = FindAnyObjectByType<GameWinNew>();

        //To hide the GAME OVER, YOU WIN and RESTART texts at the start 
        gameover.gameOverText.gameObject.SetActive(false);
        gameWin.winText.gameObject.SetActive(false);

        gameover.restartText.gameObject.SetActive(false);
        gameWin.restartText.gameObject.SetActive(false);

    }

    
    void Update()
    {   //Checking if game is not over
        if (!isGameOver)
        {   //Checking if ball falls below the position I specified
            if (transform.position.y < position)
            {
                //Game over is true so the text will be shown here
                isGameOver = true;
                gameover.ShowGameOver();
            }
            //Clamping the velocity of the ball to the specified maxvelocity
            if (rigid.velocity.magnitude > Maximumvelocity)
            {
                rigid.velocity = Vector3.ClampMagnitude(rigid.velocity, Maximumvelocity);
            }
        }
        //Checking if game is over or if we have won
        if (isGameOver || hasWon)
        {   //Checking if we pressed the enter key so that the game can restart here
            if (Input.GetKeyDown(KeyCode.Return))
            {
                ResetGame();
            }
        }
    }

    //Called when the ball collides with another object
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!isGameOver)

        {   //Checking if the ball collides with the bricks
            if (collision.gameObject.CompareTag("brick"))
            {
                Destroy(collision.gameObject);

                //For every brick destroyed the score increases by 5
                score += 5;

                //Updates the score display
                Scoretext.text = score.ToString("score: 00");

                //Referencing to gamewin script to display the YOU WIN message
                gameWin.CheckWinCondition();
            }
        }

    }

    //Resets the game to the initial position
    private void ResetGame()
    {
        transform.position = Vector3.zero;
        rigid.velocity = Vector3.zero;

        player.ResetPaddle();

        //Resets the score too
        score = 0;
        Scoretext.text = "Score:" + score.ToString(" 00");

        //Resetting brick to initial position
        GameObject[] bricks = GameObject.FindGameObjectsWithTag("brick");

       

        //To hide the game over and you win text
        gameover.HideGameOver();
        gameWin.HideWinMessage();

        isGameOver = false;
        hasWon = false;

    }
}