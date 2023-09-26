using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame

    //Gravity
    public float GravityPerSecond = 40.0f; //Falling Speed
    //Movement
    public float MovementSpeedPerSecond = 10.0f; //Movement Speed

    void Update()
    {
        //Gravity
        Vector3 gravityPosition = transform.position; //Copy Character Pos
        gravityPosition.y -= MovementSpeedPerSecond * Time.deltaTime; //Subtract Gravity*Deltatime
        transform.position = gravityPosition; //Assign New Pos to transform

        //Up
        if (Input.GetKey(KeyCode.W))
        {
            Vector3 characterPosition = transform.position; //Copy character position
            characterPosition.y += MovementSpeedPerSecond * Time.deltaTime; //Add Movementspeed + Time for Frame
            transform.position = characterPosition; //Assign New position
        }
        //Down
        if (Input.GetKey(KeyCode.S))
        {
            Vector3 characterPosition = transform.position; 
            characterPosition.y -= MovementSpeedPerSecond * Time.deltaTime; 
            transform.position = characterPosition;
        }
        //Left
        if (Input.GetKey(KeyCode.A))
        {
            Vector3 characterPosition = transform.position; 
            characterPosition.x -= MovementSpeedPerSecond * Time.deltaTime;
            transform.position = characterPosition;
        }
        //Right
        if (Input.GetKey(KeyCode.D))
        {
            Vector3 characterPosition = transform.position;
            characterPosition.x += MovementSpeedPerSecond * Time.deltaTime;
            transform.position = characterPosition;
        }

    }
}
