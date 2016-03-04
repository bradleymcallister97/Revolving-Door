using UnityEngine;
using System.Collections;

public class BlowUpCharacter : MonoBehaviour
{

    public GameObject miniBall;
    public GameObject GameOverMessage;
    // Use this for initialization
    void Start()
    {



    }



    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Door")
        {
            MoveCharacter.fl_xspeed = 0;
            MoveCharacter.fl_yspeed = 0;
            GetComponent<ParticleSystem>().Play();

            GetComponent<Collider>().enabled = false;

            for (int int_counter = 0; int_counter < 12; int_counter++)
            {

                Instantiate(miniBall, transform.position + (Random.insideUnitSphere * 0.05f), transform.rotation);

            }
            if (MoveCharacter.int_score >= 50)
            {

            }
            else if (MoveCharacter.int_score >= 35)
            {

            }
            else if (MoveCharacter.int_score >= 20)
            {

            }
            else if (MoveCharacter.int_score >= 10)
            {

            }
            else if (MoveCharacter.int_score >= 5)
            {

            }
                Instantiate(GameOverMessage);

        }

        GetComponent<Renderer>().enabled = false;
    }

}