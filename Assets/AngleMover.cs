//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class AngleMover : MonoBehaviour
//{
//   // public float minAngle, maxAngle;  // Maximum angle in degrees (180 degrees)

//    private float xMin = -3f, xMax = 3.2f;
//    private float yMin = -4.5f, yMax = 5.5f;
//    public float speed;
//    public Vector2 randomAngles;
//    public float dir;
//    public float velX, velY;
//    public Vector3 myPos;
//    float randomAngle;

//    private void Update()
//    {
//        //randomAngle = Random.Range(randomAngles.x, randomAngles.y);
//        //dir = Quaternion.Euler(new Vector3(0, 0, randomAngle)) * Vector2.right;
//        //Debug.Log("dir" + dir);
//        MoveBall();
//    }
//    public void MoveBall()
//    {
//        Vector2 newPos = transform.position;
//        Vector2 res=  dir * speed * Time.deltaTime;
//        Debug.Log("res" + res);
//        newPos.x+= dir * speed * Time.deltaTime/*res.x*/;
//        newPos.y += dir * speed * Time.deltaTime /*res.y*/;
//        transform.position = newPos;
//        BoundryCheck(transform.position);
//    }


//    public void BoundryCheck(Vector3 newPos)
//    {
//        float randomAngle;
//        if (newPos.x < xMin)
//        {
//             randomAngle = Random.Range(randomAngles.x, randomAngles.y);
//            dir = randomAngle /*Quaternion.Euler(new Vector3(0, 0, randomAngle)) * new Vector3(Mathf.Abs(velX), 1,0)*/;
            
//            Debug.Log("dir"+ dir);
//        }
//        if (newPos.x > xMax)
//        {
//            randomAngle = Random.Range(randomAngles.x, randomAngles.y);
//            dir = Quaternion.Euler(new Vector3(0, 0, randomAngle)) * new Vector3(-Mathf.Abs(velX), 1, 0);
//        }

//        if (newPos.y < yMin)
//        {
//            randomAngle = Random.Range(randomAngles.x, randomAngles.y);
//            dir = Quaternion.Euler(new Vector3(0, 0, randomAngle)) * new Vector3( 1, Mathf.Abs(velY), 0);
//        }

//        if (newPos.y > yMax)
//        {
//            randomAngle = Random.Range(randomAngles.x, randomAngles.y);
//            dir = Quaternion.Euler(new Vector3(0, 0, randomAngle)) * new Vector3(1, -Mathf.Abs(velY), 0);
//        }
//    }

//}
