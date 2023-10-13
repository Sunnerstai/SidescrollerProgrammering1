using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TODO Optional: Rename to CollisionScript
public class BlockScript : MonoBehaviour
{
    //x = Width , y = Height
    public Vector2 Dimensions = new Vector2(16.0f, 16.0f);
    //Position of the lower Left corner of the object
    public Vector2 LowerLeftCorner = new Vector2();

public static bool CheckCollisions(BlockScript aObject1, BlockScript aObject2)
{          
        //Is object1 left corner smaller than object 2 right corner?
        if (aObject1.LowerLeftCorner.x < aObject2.LowerLeftCorner.x + aObject2.Dimensions.x &&
            //Is object1 right corner bigger than object 2 left corner?
             aObject1.LowerLeftCorner.x + aObject1.Dimensions.x > aObject2.LowerLeftCorner.x &&
             //Is object 1 bottom less tall than object 2 top?
             aObject1.LowerLeftCorner.y < aObject2.LowerLeftCorner.y + aObject2.Dimensions.y &&
             //Is object1 top taller than object 2 bottom?
              aObject1.LowerLeftCorner.y + aObject2.Dimensions.y > aObject2.LowerLeftCorner.y)
        {
            return true;
        }
        return false;
}

    
    // Update is called once per frame
    void Update()
    {
        LowerLeftCorner = new Vector2(transform.position.x - (Dimensions.x * 0.5f),
            transform.position.y - (Dimensions.y * 0.5f));
    }
}
