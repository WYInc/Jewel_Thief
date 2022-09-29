using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class container2Detection : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "jewel2")
        {
            Debug.Log("correct");
            DestroyObject();
        }
        else { Debug.Log("wrong container!"); }
    }
    void DestroyObject()
    {
        Object.Destroy(gameObject, 2.0f);
    }
}
