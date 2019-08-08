using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Touchable : MonoBehaviour
{
    private bool Pressed = false;
    public bool jointed = false;
    public Rigidbody2D player;
    public Vector2 jointPos;
    //public Rigidbody2D joint;
    //public float releaseTime=0.15f;
    public float jointRange=2f;
    private Rigidbody2D rb;
    public float stringVel;
    private Vector2 mouse;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Pressed && jointed)
        {
            
            mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (Vector3.Distance(mouse, jointPos) > jointRange)
            {
                player.position = jointPos + (mouse - jointPos).normalized * jointRange;
            }
            else
                player.position = mouse;
            
        }
        /*Vector2 mouse =Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Vector3.Distance(mouse, joint.position) > jointRange)
        {
            player.position = joint.position+(mouse-joint.position).normalized * jointRange;
        }
        else
            player.position = mouse;
          */
        
    
    }

    private void OnMouseDown()
    {
        Pressed = true;
        player.isKinematic = true;

    }
    private void OnMouseUp()
    {
        Pressed = false;
        player.isKinematic = false;
        jointed = false;
        if (((mouse - jointPos).magnitude) < jointRange)
        {
            rb.AddForce(-((mouse - jointPos).normalized) * (stringVel) * ((mouse - jointPos).magnitude));
        }
        else
        {
            rb.AddForce(-((mouse - jointPos).normalized) * (stringVel) * (jointRange));
        }
        this.GetComponent<tailFollow>().tail.GetComponent<SpriteRenderer>().enabled = false;
        //StartCoroutine(Fly());
    }


    /*
    IEnumerator Fly()
    {
        yield return new WaitForSeconds(releaseTime);
        GetComponent<SpringJoint2D>().enabled = false;
       


    }*/

}
