using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    private float xpos;
    private float startpos;
    // Start is called before the first frame update
    void Start()
    {
        xpos = 0;
        startpos = this.transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        xpos = player.transform.position.x;
        this.transform.position = new Vector3(startpos+xpos, this.transform.position.y, this.transform.position.z);
       
    }
}
