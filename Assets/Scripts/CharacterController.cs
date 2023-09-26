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

    public float MovementSpeedPerSecond = 10.0f;
    void Update()
    {
        //Up
        if (Input.GetKey(KeyCode.W))
        {
            Vector3 characterPosition = transform.position; //Position av karäktären
            characterPosition.y += MovementSpeedPerSecond * Time.deltaTime; //Hur snabbt karäktären rör sig gånger
            transform.position = characterPosition; 
        }
        //Down
        if (Input.GetKey(KeyCode.S))
        {
            Vector3 characterPosition = transform.position; //Position av karäktären
            characterPosition.y -= MovementSpeedPerSecond * Time.deltaTime; //Hur snabbt karäktären rör si
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
            Vector3 characterPosition = transform.position; //Position av karäktären
            characterPosition.x += MovementSpeedPerSecond * Time.deltaTime; //Hur snabbt karäktären rör sig gånger
            transform.position = characterPosition;
        }

    }
}
