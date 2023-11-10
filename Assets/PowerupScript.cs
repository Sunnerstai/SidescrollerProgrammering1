using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupScript : MonoBehaviour
{
    public int addHealth = 1;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var BaconScript = collision.gameObject.GetComponent<PhysicsCharacterController>();
        if (BaconScript != null) //!= betyder om det inte är likamed, 
        {
            BaconScript.HP += addHealth;
            addHealth = 0;
            GameObject.Destroy(BaconScript);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}

