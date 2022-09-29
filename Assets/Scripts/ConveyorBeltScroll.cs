using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorBeltScroll : MonoBehaviour
{
    public float scrollSpeed = 1f;
    //public float Lifespan = 3f;
    //private float SectionLife = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * scrollSpeed * Time.deltaTime);
        //if (SectionLife >= Lifespan)
        //{
        //    Destroy(gameObject);
        //}
        //else
        //{
        //    SectionLife = SectionLife + Time.deltaTime;

        //}
    }
}
