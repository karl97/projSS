using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    
    private float xpos;
    private float startpos;
    private float maxX;
    private float startX;
    private float height;
    private float width;
    
        // Start is called before the first frame update

    void Start()
    {
        xpos = 0;
        startpos = this.transform.position.x;
        maxX= player.transform.position.x;
        startX = maxX;
        Camera cam = Camera.main;
        height = 2f * cam.orthographicSize;
        width = height * cam.aspect;
    }

    // Update is called once per frame
    void Update()
    {
        xpos = player.transform.position.x;
        if ((maxX < xpos)&&!player.GetComponent<Touchable>().jointed)
        {
            maxX = xpos;
            //if((startpos)>(startX-xpos))
            this.transform.position = new Vector3(startpos + xpos-startX, this.transform.position.y, this.transform.position.z);
        }
    }
   
}
