using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupScript : MonoBehaviour
{
    public int addHealth = 2;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var Shades = collision.gameObject.GetComponent<PhysicsCharacterController>();
        if (Shades != null) //!= betyder om det inte är likamed, 
        {
            Shades.HP += addHealth;
            addHealth = 0;
            GameObject.Destroy(gameObject);
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

