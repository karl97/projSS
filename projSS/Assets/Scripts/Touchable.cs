using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Touchable : MonoBehaviour
{
    public AudioSource jump;
    private bool Pressed = false;
    public bool jointed = false;
    public Rigidbody2D player;
    public Vector2 jointPos;
    //public Rigidbody2D joint;
    //public float releaseTime=0.15f;
    public float jointRange;
    private Rigidbody2D rb;
    public float stringVel;
    private Vector2 mouse;


    // Start is called before the first frame update
    void Start()
    {
        jointRange = 3f;
        PlayerPrefs.SetInt("Score", 0);//for the score to always be set to 0 in the beginneing of the game
        
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
        if (jointed)
        {
            this.GetComponent<Animator>().SetBool("Isclicked", true);
            Pressed = true;
            player.isKinematic = true;
        }

    }
    private void OnMouseUp()
    {
        if (jointed)
        {
            
            Pressed = false;
            player.isKinematic = false;

            if (((mouse - jointPos).magnitude) < jointRange)
            {
                rb.AddForce(-((mouse - jointPos).normalized) * (stringVel) * ((mouse - jointPos).magnitude));
                
            }
            else
            {
                rb.AddForce(-((mouse - jointPos).normalized) * (stringVel) * (jointRange));
                
            }
            jump.Play();
            jointed = false;
            this.GetComponent<Animator>().SetBool("Isclicked", false);
            this.GetComponent<Animator>().SetBool("isJointed", false);
            this.GetComponent<tailFollow>().tail.GetComponent<SpriteRenderer>().enabled = false;
            this.GetComponent<tailFollow>().tail2.GetComponent<SpriteRenderer>().enabled = true;
        }
    }


    /*
    IEnumerator Fly()
    {
        yield return new WaitForSeconds(releaseTime);
        GetComponent<SpringJoint2D>().enabled = false;
       


    }*/

}
