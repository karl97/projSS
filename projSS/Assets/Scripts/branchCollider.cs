using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class branchCollider : MonoBehaviour
{
    public GameObject particles;
    //public Rigidbody2D joint;
    //public Rigidbody2D player;
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
            particles.transform.position = this.transform.position;

            particles.GetComponent<ParticleSystem>().Play(true);

            collision.gameObject.GetComponent<Touchable>().jointed=true;
            collision.gameObject.GetComponent<Touchable>().jointPos = this.transform.position;
            collision.gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0);
            collision.gameObject.transform.position = this.transform.position;
            //joint.position = this.transform.position;
            //player.GetComponent<SpringJoint2D>().enabled = true;
            GetComponent<BoxCollider2D>().enabled = false;
            collision.gameObject.GetComponent<tailFollow>().tail.transform.position = this.transform.position;
            collision.gameObject.GetComponent<tailFollow>().tail.GetComponent<SpriteRenderer>().enabled = true;
        }
    }

}
