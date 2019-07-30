using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Touchable : MonoBehaviour
{
    private bool Pressed = false;
    public Rigidbody2D player;
    public Rigidbody2D joint;
    public float releaseTime=0.15f;
    public float jointRange=2f;



    // Start is called before the first frame update
    void Start()
    {
        GetComponent<SpringJoint2D>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Pressed && GetComponent<SpringJoint2D>().enabled)
        {
            Vector2 mouse =Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (Vector3.Distance(mouse, joint.position) > jointRange)
            {
                player.position = joint.position+(mouse-joint.position).normalized * jointRange;
            }
            else
                player.position = mouse;
                    
        }
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

        StartCoroutine(Fly());
    }

    IEnumerator Fly()
    {
        yield return new WaitForSeconds(releaseTime);
        GetComponent<SpringJoint2D>().enabled = false;
       


    }

}
