using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaconScript : MonoBehaviour
{
    [SerializeField] int testInt = 5;
    public int HP = 0;

    public void TakeDamage(int aHPValue)
    {
        HP += aHPValue;
        if (HP > 0)
        {
            GameObject.Destroy(gameObject);
        }
    }

    public float MovementSpeedPerSecond = 10.0f; //Movement speed
    public int MovementSign = 1;

    public Rigidbody2D myRigidBody = null;

    void Start()
    {
        
    }


    void FixedUpdate() //Det händer med en konstant hastighet
    {
        Vector3 characterVelocity = myRigidBody.velocity; //Kopia av vår snabbhet
        characterVelocity.x = 0; //Nu accelererar den inte, x axeln blir inte påverkad av gravitation

        //add velocity in characters right direction, Movement sign = 1 eller 0 
        characterVelocity += MovementSign * MovementSpeedPerSecond * transform.right.normalized;

        myRigidBody.velocity = characterVelocity;

        //Debug.Log("Velocity is: " + myRigidBody.velocity);
    }

    // Example of a Getter method
    public int GetTestInt()
    {
        return testInt;
    }

    // Get = Gets the value, cannot change it
    // Set = Sets the value, can change it
}
