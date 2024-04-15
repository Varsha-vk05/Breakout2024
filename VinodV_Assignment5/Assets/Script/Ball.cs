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
    public TextMeshProUGUI over;
    bool isgameover = false;



    void Start()
    {
        over.gameObject.SetActive(false);

        rigid = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        if (!isgameover)
        {
            if (transform.position.y < position)
            {
                isgameover = true;
                GameOver();
                // transform.position = Vector3.zero;
                //rigid.velocity = Vector3.zero;


            }

            if (rigid.velocity.magnitude > Maximumvelocity)
            {
                rigid.velocity = Vector3.ClampMagnitude(rigid.velocity, Maximumvelocity);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!isgameover)
        {
            if (collision.gameObject.CompareTag("brick"))
            {
                Destroy(collision.gameObject);
                score += 5;
                Scoretext.text = score.ToString("score: 00");
            }
        }

    }

    void GameOver()
    {
        isgameover = true;
        over.gameObject.SetActive(true);
        over.text = "GAME OVER";


    }
}
