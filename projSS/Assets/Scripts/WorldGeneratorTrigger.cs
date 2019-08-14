using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class WorldGeneratorTrigger : MonoBehaviour
{
    
    public GameObject w1;
    public int counter;
    private float width;
    private Vector3 startpos;
    // Start is called before the first frame update
    void Start()
    {
        startpos = w1.transform.position;
        GameObject child = w1.transform.GetChild(1).gameObject;
        width = child.GetComponent<Renderer>().bounds.size.x;
        counter = 3;



        GameObject w2 = Instantiate(w1) as GameObject;
        GameObject w3 = Instantiate(w1) as GameObject;
        w2.transform.position = new Vector3(startpos.x + width, startpos.y, startpos.z);
        w3.transform.position = new Vector3(startpos.x + width*2f, startpos.y, startpos.z);
        //this.transform.position= new Vector3(startpos.x + width*1.5f, startpos.y, startpos.z);
        w1 = w3;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void spawnWorld()
    {
        GameObject a = Instantiate(w1) as GameObject;
        
        a.transform.position = new Vector3(startpos.x+(width*(counter)),startpos.y,startpos.z);
        GameObject treeAndBranch = a.transform.GetChild(2).gameObject;
        GameObject branch= treeAndBranch.transform.GetChild(0).gameObject;
        w1 = a;
        branch.transform.position = new Vector3(branch.transform.position.x, startpos.y+Random.Range(-3f, 3f), startpos.z);
        
       
    }

    private void deleteworld()
    {
        foreach (GameObject world in GameObject.FindGameObjectsWithTag("world"))
        {
            
            if (world.transform.position.x<this.transform.position.x-width*2f)//width*2fmakes 4 worlds all the time
            {
               
                Destroy(world);
            }
        }



    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log(counter);
            spawnWorld();
            this.transform.position = new Vector3(this.transform.position.x+width, this.transform.position.y, this.transform.position.z);
            deleteworld();
            counter++;
           


        }
    }
}
