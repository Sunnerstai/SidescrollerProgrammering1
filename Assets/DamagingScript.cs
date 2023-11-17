using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class DamagingScript : MonoBehaviour
{
    public bool IsPlayer = false;

    public int AddDamage = -1;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (IsPlayer)
        {
            var EnemyScript = collision.gameObject.GetComponent<PhysicsCharacterController>();
            if (EnemyScript != null) //!= betyder om det inte är likamed, 
            {
                EnemyScript.TakeDamage(AddDamage); //change playerscript from shades to playerscript
            }
        }
        else
        {
            var PlayerScript = collision.gameObject.GetComponent<PhysicsCharacterController>();
            if (PlayerScript != null) //!= betyder om det inte är likamed, 
            {
                PlayerScript.TakeDamage(AddDamage); //Change Shades to enemy script
            }
        }
    }
}
