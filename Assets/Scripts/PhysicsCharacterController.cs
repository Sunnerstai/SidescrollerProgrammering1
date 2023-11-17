using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;

public enum CharacterState
{
    Grounded = 0, //Is on the ground
    Airborne = 1, //Is in the air
    Jumping = 2, //Is currently jumping
    Total
}
    

public class PhysicsCharacterController : MonoBehaviour
{
    public SpriteRenderer mySpriteRenderer = null;
    public List<Sprite> CharacterSprite = new List<Sprite>();
    public int HP = 1;
    //Refrence to rigidbody on same object
    public Rigidbody2D myRigidBody = null;

    public CharacterState JumpingState = CharacterState.Airborne;
    //Is Our character on the ground or in the air?

    //Gravity
    public float GravityPerSecond = 160.0f; //Falling Speed
    public float GroundLevel = 0.0f; //Ground Value

    //Jump
    public float JumpSpeedFactor = 3.0f; //How much faster is the jump than the movespeed?
    public float JumpMaxHeight = 150.0f;
    [SerializeField]
    private float JumpHeightDelta = 0.0f;
    private float JumpStartingY = 0.0f;

    //Movement
    public float MovementSpeedPerSecond = 10.0f; //Movement Speed

   
    private void Update()
    {
        //Kolla of HP är mindre än 0
        if(HP > 0) 
        {
            //Försöka få en referenns to SceneLoaderScript på det här gameObjektet
            SceneLoader mySceneLoader = gameObject.GetComponent<SceneLoader>();
            //Funkar eller inte
            if(mySceneLoader != null)
            {
                mySceneLoader.LoadScene("Main Menu");
            }
        }
        //Kopiera hp för att inte ändra karäktärens hp
        int HPCopy = HP - 1;
        if(HPCopy < 0)
        {
            HPCopy = 0;
        }
        if (HPCopy >= CharacterSprite.Count)
        {
            HPCopy = CharacterSprite.Count -1;
        }
        mySpriteRenderer.sprite = CharacterSprite[HPCopy];
        if (Input.GetKeyDown(KeyCode.Space) && JumpingState == CharacterState.Grounded)
        {
            JumpingState = CharacterState.Jumping; //Set character to jumping
            JumpHeightDelta = 0.0f; //Restart Counting Jumpdistance
            JumpStartingY = transform.position.y;
        }
    }


    void FixedUpdate()
    {
     

        Vector3 characterVelocity = myRigidBody.velocity;
        characterVelocity.x = 0.0f;

        if (JumpingState == CharacterState.Jumping)
        {
            float totalJumpMovementThisFrame = MovementSpeedPerSecond * JumpSpeedFactor;
            characterVelocity.y = totalJumpMovementThisFrame;

            JumpHeightDelta += totalJumpMovementThisFrame * Time.deltaTime;

            if (JumpHeightDelta >= JumpMaxHeight)
            {
                JumpingState = CharacterState.Airborne;
                JumpHeightDelta = 0.0f;
                characterVelocity.y = 0.0f;
            }
        }

        //Left
        if (Input.GetKey(KeyCode.A))
        {
            characterVelocity.x -= MovementSpeedPerSecond;
        }
        //Right
        if (Input.GetKey(KeyCode.D))
        {
            characterVelocity.x += MovementSpeedPerSecond;
        }
        myRigidBody.velocity = characterVelocity;
    }
    public void TakeDamage(int aHPValue)
    {
        HP += aHPValue;
    }
}