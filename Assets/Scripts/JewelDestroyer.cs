using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JewelDestroyer : MonoBehaviour
{

    //public GameObject Game_Manager;

    // Start is called before the first frame update

    public void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
    }
}
