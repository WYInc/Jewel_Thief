using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstructionDelay : MonoBehaviour
{

    public GameObject InstructionCanvass;
    public GameObject JewelSpawner;
    public Transform SpawnSpot;
    public int DelayLenght;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(delayedSpawn(DelayLenght));
    }

    IEnumerator delayedSpawn(int howLong)
    {
        yield return new WaitForSeconds(howLong);
        InstructionCanvass.SetActive(false);
        Instantiate(JewelSpawner, SpawnSpot);

    }
}
