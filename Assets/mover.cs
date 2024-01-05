using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mover : MonoBehaviour
{
    public float minAngle, maxAngle; 
   
    private float xMin =-3f, xMax=3.2f ;
    private float yMin = -4.5f, yMax = 5.5f;
    public float speed;

   
    public float  velX,velY;
    public Vector3 myPos;

    private void Update()
    {
        
        ChangePostion();
       
    }



    public void ChangePostion()
    {
        Vector3 newPos = transform.position;
        BoundryCheck(newPos);
        float rabdomMultiplier = Random.Range(1f, 1.2f);
        newPos.x += velX* rabdomMultiplier;
        newPos.y += velY* rabdomMultiplier;
        transform.position = newPos;
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
       
            Vector2 collisionObjPos = collision.gameObject.transform.position;
             Vector2 thisObjPos = this.gameObject.transform.position;
          if (collisionObjPos.x < thisObjPos.x)
            {
            velX = Mathf.Abs(velX);
            }
            if (collisionObjPos.x > thisObjPos.x)
            {
            velX =  -Mathf.Abs(velX);
            }

        if (collisionObjPos.y < thisObjPos.y)
        {
            velY = Mathf.Abs(velY);
        }
        if (collisionObjPos.y > thisObjPos.y)
        {
            velY = -Mathf.Abs(velY);
        }

    }

    public void BoundryCheck(Vector3  newPos)
    {
       
        if (newPos.x<xMin)
        {
           
            velX = Mathf.Abs(velX);
        }
        if (newPos.x > xMax)
        {
            velX = -Mathf.Abs(velX );
        }

        if (newPos.y< yMin)
        {
            velY = Mathf.Abs(velY);
        }

        if (newPos.y > yMax)
        {
            velY = -Mathf.Abs(velY);
        }
    }

}
