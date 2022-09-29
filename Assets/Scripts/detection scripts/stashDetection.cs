using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stashDetection : MonoBehaviour
{
    public GameObject Game_Manager;
    [HideInInspector]
    public string JewelTag;

    public GameObject Jingle;

    void OnTriggerEnter(Collider other)
    {
        Jingle.gameObject.GetComponent<AudioSource>().Play();
        JewelTag = other.gameObject.tag;
        Game_Manager.gameObject.GetComponent<Game_Manager>().checkStolen(JewelTag);
        Destroy(other.gameObject);
        //if (other.gameObject.tag == "special")
        //{
        //    Debug.Log("correct");
        //    DestroyObject();
        //}
        //else { Debug.Log("wrong container!"); }
    }
    //void DestroyObject()
    //{
    //    Object.Destroy(gameObject, 2.0f);
    //}
}
