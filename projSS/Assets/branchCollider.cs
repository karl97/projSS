using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class branchCollider : MonoBehaviour
{
    public Rigidbody2D joint;
    public Rigidbody2D player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("HITBRANCH");
            joint.position = this.transform.position;
            player.GetComponent<SpringJoint2D>().enabled = true;
            Destroy(GetComponent<BoxCollider2D>());
        }
    }

}
