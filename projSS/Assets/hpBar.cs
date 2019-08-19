using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hpBar : MonoBehaviour
{
    public GameObject player;
    private Image hp1;
    private Image hp2;
    private Image hp3;
    private Image ghp1;
    private Image ghp2;
    private Image ghp3;
    // Start is called before the first frame update
    void Start()
    {
        hp1=this.transform.GetChild(0).gameObject.GetComponent<Image>();
        hp2=this.transform.GetChild(1).gameObject.GetComponent<Image>();
        hp3=this.transform.GetChild(2).gameObject.GetComponent<Image>();
        ghp1=this.transform.GetChild(3).gameObject.GetComponent<Image>();
        ghp2=this.transform.GetChild(4).gameObject.GetComponent<Image>();
        ghp3=this.transform.GetChild(5).gameObject.GetComponent<Image>();

        hp1.enabled = false;
        hp2.enabled = false;
        hp3.enabled = false;
    }
        // Update is called once per frame
        void Update()
    {

        if (player.GetComponent<HP>().health == 1)
        {
            hp1.enabled = true;
            hp2.enabled = false;
            hp3.enabled = false;
            ghp1.enabled = false;
            ghp2.enabled = true;
            ghp3.enabled = true;


        }
        else if(player.GetComponent<HP>().health == 2) {
            hp1.enabled = true;
           hp2.enabled = true;
            hp3.enabled = false;
           ghp1.enabled = false;
            ghp2.enabled = false;
            ghp3.enabled = true;
        }
        else if(player.GetComponent<HP>().health == 3) {
            hp1.enabled = true;
            hp2.enabled = true;
          hp3.enabled = true;
            ghp1.enabled = false;
           ghp2.enabled = false;
           ghp3.enabled = false;
        }
        else if (player.GetComponent<HP>().health <1) { 
            hp1.enabled = false;
           hp2.enabled = false;
           hp3.enabled = false;
            ghp1.enabled = true;
           ghp2.enabled = true;
           ghp3.enabled = true;
        }

    }
}
