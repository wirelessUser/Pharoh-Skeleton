using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonEnemy : MonoBehaviour
{
   

   

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Vector2 shootDir = transform.position - collision.transform.position;
        if (collision.tag=="Bullet")
        {
            if (transform.GetChild(0).gameObject.GetComponent<Rigidbody2D>().gravityScale<1)
            {
                GetComponent<Rigidbody2D>().AddForce(new Vector2((shootDir.x > 0 ? 1 : -1), shootDir.y > 0 ? 1 : -1), ForceMode2D.Impulse);
                SkeletonDieFallBySettingGravity();
            }
        }

        //...

        if (collision.gameObject.tag=="Box" || collision.gameObject.tag == "Steelbar")
        {
            if (collision.GetComponent<Rigidbody2D>().velocity.magnitude>1)
            {
                SkeletonDieFallBySettingGravity();
                Debug.Log("Hit by Box");
            }
        }

        if (collision.gameObject.tag=="Ground")
        {
           if(this.GetComponent<Rigidbody2D>().velocity.magnitude > 1)
            {
                SkeletonDieFallBySettingGravity();
                Debug.Log("Hit by Ground");
            }
        }
    }


    public void SkeletonDieFallBySettingGravity()
    {
        
        foreach (Transform childs in this.transform)
        {
            childs.GetComponent<Rigidbody2D>().gravityScale = 1;
        }
    }

}
