using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JewelSpawnScript : MonoBehaviour
{
    public Transform SpawnPoint;
    public GameObject Jewel1;
    public GameObject Jewel2;
    public GameObject Jewel3;
    public GameObject Jewel4;
    public float Timer = 0f;
    public float TimerDuration = 1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Timer >= TimerDuration)
        {

            SpawnJewels();
            Timer = 0f;

        }
        else
        {
            Timer = Timer + Time.deltaTime;
        }
    }

    void SpawnJewels()
    {
        Instantiate(Jewel2, SpawnPoint.position, Quaternion.identity);
    }
}
