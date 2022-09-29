using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class container1Detection : MonoBehaviour
{
    //added so that script can access variables in Game_Manager script
    public GameObject Game_Manager;
    //added var below so same script could be used for each
    //container, with correct tag defined in inspector
    public string CorrectTag;

    public GameObject JingleSound;
    void OnTriggerEnter(Collider other)
    {
        JingleSound.gameObject.GetComponent<AudioSource>().Play();
        if (other.gameObject.tag == CorrectTag)
        {
            //Debug.Log("correct");
            Game_Manager.gameObject.GetComponent<Game_Manager>().PlayerScore += 10;
            Game_Manager.gameObject.GetComponent<Game_Manager>().updateScore();
            Destroy(other.gameObject);
        }
        else { //Debug.Log("wrong container!");
            Destroy(other.gameObject);
            //Game_Manager.gameObject.GetComponent<Game_Manager>().Suspcion += 1;
            Game_Manager.gameObject.GetComponent<Game_Manager>().winOrLose();

        }
    }
    //void DestroyObject()
    //{
    //    Destroy(other.gameObject);
    //    //Object.Destroy(gameObject, 2.0f);
    //}
}
