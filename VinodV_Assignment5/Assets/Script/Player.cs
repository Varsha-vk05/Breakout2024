using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    public float speed = 10;
    public float paddlemax = 8f;
    float paddlehorizontal;
   
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        paddlehorizontal = Input.GetAxis("Horizontal");

        if ((paddlehorizontal > 0 && transform.position.x < paddlemax) || (paddlehorizontal < 0 && transform.position.x > -paddlemax))
        {
            transform.position += Vector3.right * paddlehorizontal * speed * Time.deltaTime;
        }
    }
}
