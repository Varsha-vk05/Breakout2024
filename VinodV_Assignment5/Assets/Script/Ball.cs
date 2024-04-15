using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float position = -5f;
    public float Maximumvelocity = 15f;
    Rigidbody2D rigid;
    int score = 0;
    public TextMeshProUGUI Scoretext;

    private GameOver gameover;
    private bool isGameOver = false;
    private GameWin gameWin;
    private bool hasWon=false;




    void Start()
    {
       

        rigid = GetComponent<Rigidbody2D>();
        gameover=FindAnyObjectByType<GameOver>();
        gameWin = FindAnyObjectByType<GameWin>();

        gameover.HideGameOver();
        gameWin.HideWinMessage();

    }

    // Update is called once per frame
    void Update()
    {
        if (!isGameOver)
        {
            if (transform.position.y < position)
            {
                isGameOver = true;
                gameover.ShowGameOver();
                
            }

            if (rigid.velocity.magnitude > Maximumvelocity)
            {
                rigid.velocity = Vector3.ClampMagnitude(rigid.velocity, Maximumvelocity);
            }
        }

        if (isGameOver || hasWon)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                ResetGame();
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!isGameOver)
        {
            if (collision.gameObject.CompareTag("brick"))
            {
                Destroy(collision.gameObject);
                score += 5;
                Scoretext.text = score.ToString("score: 00");

                gameWin.CheckWinCondition();
            }
        }

    }

    private void ResetGame()
    {
        transform.position=Vector3.zero;
        rigid.velocity=Vector3.zero;

        score = 0;
        Scoretext.text ="Score:"+ score.ToString(" 00");

        gameover.HideGameOver();
        gameWin.HideWinMessage();

        isGameOver=false;
        hasWon=false;

    }
}
