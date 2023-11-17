using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalScript : MonoBehaviour
{
    public SceneLoader mySceneLoader = null;
    public string NextScene = "MainMenu";
    private void OnCollisionEnter2D(Collision2D collision)
    {
        var Shades = collision.gameObject.GetComponent<PhysicsCharacterController>();
        if (Shades != null)
        {
            mySceneLoader.LoadScene(NextScene);
        }
    }
}




 