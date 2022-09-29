using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class jewelInstantiation : MonoBehaviour
{
    //public int InstructionCountdown;
    //public bool WaitForInstructions = true;

    float timer = 3;

    private float startTimer = 2;
    public int numOfJewels = 3;
    public int specialJewelChance = 10;

    int jewelPicked;
    int jewelAmount;
    public GameObject[] jewels;
    public GameObject selectedJewel;
    public Transform spawnLocation;

    public GameObject specialJewel;

    [HideInInspector]
    public Scene CurrentScene;
    public string BonusScene = "SurvivalRound";



    private void Start()
    {
        CurrentScene = SceneManager.GetActiveScene();
    }
    void Update()
    {
        //if (WaitForInstructions == true)
        //{

        //}
        //Adjustments made to make script work with numOfJewels set to "1". To make script work with numOfJewels set to 2 or more, delete
        //line 38 and "else" clause surrounding lines 43-35 - BW
       
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            int specialJewelR = Random.Range(1, specialJewelChance);
            if (specialJewelR == 1)
            {
                specialJewelSpawn();
                
                //line below was only in "else" statement; copied to "if" also, since this was cause of other jewels still being spawned at same time as special
                //when numOfJewels was set to "1" - BW
                timer = startTimer;
            }
            //"else" added because when numOfJewels set to "1" in inspector, special jewels were spawning along with another jewel, rather than alone - BW
            else
            {
                jewelAmount = Random.Range(1, numOfJewels);
                randomJewel();
                timer = startTimer;
            }

            if (CurrentScene.name == BonusScene)
            {
                startTimer -= .01f;
                Debug.Log("anything?");
            }


        }
       
    }


    //IEnumerator delayJewelSpawn(int waitTime)
    //{
    //    yield return new WaitForSeconds(waitTime);
    //}

    void randomJewel()
    {
        for (var i = 0; i < jewelAmount; i++)
            Instantiate(jewels[UnityEngine.Random.Range(0, jewels.Length)], spawnLocation.position, spawnLocation.rotation);
    }
    void specialJewelSpawn() 
    {
        Instantiate(specialJewel, spawnLocation.position, spawnLocation.rotation);
    }
}
