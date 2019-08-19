using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundCollider : MonoBehaviour
{
    public GameObject blood;
    public AudioSource die;
    public int DMG;
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {

    }


    private void goToNextBranch(GameObject player) {



    }




    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<HP>().health = collision.gameObject.GetComponent<HP>().health - DMG;
            if (collision.gameObject.GetComponent<HP>().health < 1)
            {
                collision.GetComponent<Rigidbody2D>().velocity = new Vector2(0, collision.GetComponent<Rigidbody2D>().velocity.y);
                blood.transform.position = collision.transform.position;
                blood.GetComponent<ParticleSystem>().Play(true);
                die.Play();

                StartCoroutine(Die());
            }
            else { goToNextBranch(collision.gameObject); }
            }

        
    }

    IEnumerator Die()
    {
        if (PlayerPrefs.GetInt("Score") > PlayerPrefs.GetInt("Highscore"))
        {

            PlayerPrefs.SetInt("Highscore", PlayerPrefs.GetInt("Score")-1);
        }
        yield return new WaitForSeconds(1);
        Application.LoadLevel("Game");
    }
}

