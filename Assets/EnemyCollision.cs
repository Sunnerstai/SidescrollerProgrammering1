using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    [SerializeField] BaconScript myEnemyScript = null;
    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Copy enemy scale
        Vector3 enemyScale = myEnemyScript.transform.localScale;
        //Multiply X-scale by -1
        enemyScale.x = -enemyScale.x;
        myEnemyScript.transform.localScale = enemyScale;
        myEnemyScript.MovementSign *= -1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
