using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    //Speed of the paddle
    public float speed = 10;

    //MaxHorizontal position of paddle 
    public float paddlemax = 9f;
    float paddlehorizontal;

    //Initial position of paddle 
    private Vector3 initialPosition;

    private void Start()
    {
        //Stroing initial position
        initialPosition=transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //Gets the hosrixonatl input from us, LEFT OR RIGHT KEYS 
        float paddlehorizontal = Input.GetAxis("Horizontal");

        if ((paddlehorizontal > 0 && transform.position.x < paddlemax) || (paddlehorizontal < 0 && transform.position.x > -paddlemax))
        {
            //Can move the paddle only within the defined bounds 
            transform.position += Vector3.right * paddlehorizontal * speed * Time.deltaTime;
        }
    }

    public void ResetPaddle()
    {
        //Resetting the paddle to the initial position
       transform.position = initialPosition;
    }
}
