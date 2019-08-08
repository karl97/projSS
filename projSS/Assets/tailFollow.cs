using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tailFollow : MonoBehaviour
{
    public GameObject tail;
    
    // Start is called before the first frame update
    void Start()
    {
        
        tail.GetComponent<SpriteRenderer>().enabled = false;
     
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 vec=new Vector3(-1, 0, 0);
        

        float angle  = Mathf.Atan2( tail.transform.position.y-this.transform.position.y, tail.transform.position.x-this.transform.position.x) * Mathf.Rad2Deg;
        tail.transform.rotation = Quaternion.Euler(0, 0,angle);

        tail.transform.localScale=new Vector3(((this.transform.position - tail.transform.position).magnitude/2f), tail.transform.localScale.y, tail.transform.localScale.z);





    }
}
