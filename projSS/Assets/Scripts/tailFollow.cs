using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tailFollow : MonoBehaviour
{
    public GameObject tail;
    public GameObject tail2;
    private Vector2 oldpos;
    private float oldangle;
    private float yScal;
    private float xScal;
    private float angle;
    private float intervall;
   
    // Start is called before the first frame update
    void Start()
    {
        intervall = 10;
        oldangle = 0;
        oldpos = this.transform.position;
        xScal = tail.transform.localScale.x;
        yScal =tail.transform.localScale.y;
        tail.GetComponent<SpriteRenderer>().enabled = false;
        tail2.GetComponent<SpriteRenderer>().enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
           tail2.transform.position = this.transform.position;//make tail always follow player

        angle = Mathf.Atan2(this.transform.position.y - oldpos.y, this.transform.position.x - oldpos.x) * Mathf.Rad2Deg;
        if (angle > oldangle + intervall)
        {
            tail2.transform.rotation = Quaternion.Euler(0, 0, oldangle + 5);//if the new angle is outside the intervall add scalar instead so it will be more smooth
            oldangle = oldangle + 5;
        }
        else if (angle < oldangle - intervall)
        {
            tail2.transform.rotation = Quaternion.Euler(0, 0, oldangle - 5);
            oldangle = oldangle - 5;
        }
        else
        {
            tail2.transform.rotation = Quaternion.Euler(0, 0, angle);
            oldangle = angle;
        }
            oldpos = this.transform.position;
         
           
           
            
        
        angle  = Mathf.Atan2( tail.transform.position.y-this.transform.position.y, tail.transform.position.x-this.transform.position.x) * Mathf.Rad2Deg;
        tail.transform.rotation = Quaternion.Euler(0, 0,angle);//rotates the tail when bound to branch
        if ((2f / (tail.transform.position - this.transform.position).magnitude) * yScal > yScal)//stretches the tail when on the branch
        {
            tail.transform.localScale = new Vector3(((tail.transform.position - this.transform.position).magnitude / 2f) * xScal, yScal, tail.transform.localScale.z);
        }
        else
        {
            tail.transform.localScale = new Vector3(((tail.transform.position - this.transform.position).magnitude / 2f) * xScal, (2f / (tail.transform.position - this.transform.position).magnitude) * yScal, tail.transform.localScale.z);
        }




    }
}
