using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JewelPenaltyScript : MonoBehaviour
{
    public GameObject Game_Manager;

    public GameObject Alarm;

    // Start is called before the first frame update
    public void OnTriggerEnter(Collider other)
    {
        Game_Manager.gameObject.GetComponent<Game_Manager>().Suspcion += 1; 
        Destroy(other.gameObject);
        Game_Manager.gameObject.GetComponent<Game_Manager>().winOrLose();
        Game_Manager.gameObject.GetComponent<Game_Manager>().updateSuspicion();

        Alarm.gameObject.GetComponent<AudioSource>().Play();
    }
}
