using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CharacterState // An enumerated list of character states
{
    Grounded = 0,
    Airborne = 1,
    Jumping = 2,
    Total
}

public class CharacterController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame

    //Gravity
    public float GravityPerSecond = 40.0f; //Falling Speed
    public float GroundLevel = 0.0f; //Ground Value

    //Jump
    public CharacterState JumpingState = CharacterState.Grounded;
    public float JumpSpeedFactor = 3.0f; //How much faster is the 
    public float JumpMaxHeight = 150.0f;
    private float JumpHeightDelta = 0.0f;

    //Movement
    public float MovementSpeedPerSecond = 10.0f; //Movement Speed

    void Update()
    {
        //Gravity
        if(JumpingState != CharacterState.Jumping)
        {
            Vector3 gravityPosition = transform.position; //Copy Character Pos
            gravityPosition.y -= MovementSpeedPerSecond * Time.deltaTime; //Subtract Gravity*Deltatime
            if (gravityPosition.y <= GroundLevel) 
            {
                JumpingState = CharacterState.Grounded;
                gravityPosition.y = GroundLevel;
            } //Set Character To Ground Level
            transform.position = gravityPosition; //Assign New Pos to transform
        }
        //Up
        if (Input.GetKey(KeyCode.W) && JumpingState == CharacterState.Grounded)
        {
            JumpingState = CharacterState.Jumping;
            JumpHeightDelta = 0.0f;
        }
        if(JumpingState == CharacterState.Jumping)
        {
            if(JumpHeightDelta <= JumpMaxHeight)
            {
                Vector3 characterPosition = transform.position;
                characterPosition.y += MovementSpeedPerSecond * JumpSpeedFactor * Time.deltaTime;
                JumpHeightDelta += MovementSpeedPerSecond * JumpSpeedFactor * Time.deltaTime;
                transform.position = characterPosition;
            }
            else
            {
                JumpingState = CharacterState.Airborne;
            }
         
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
