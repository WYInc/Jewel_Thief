using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorBeltImageSpawn : MonoBehaviour
{
    public GameObject ConveyorImageSection;
    public float TimerDuration = 1f;
    public float Timer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Timer >= TimerDuration)
        {

            Instantiate(ConveyorImageSection, gameObject.transform);
            Timer = 0f;

        }
        else
        {
            Timer = Timer + Time.deltaTime;
        }
    }
}
