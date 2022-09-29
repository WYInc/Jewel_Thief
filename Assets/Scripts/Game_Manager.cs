using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Game_Manager : MonoBehaviour
{
    //number of times player caught stealing on camera, shows as filled cells in suspicion meter
    [HideInInspector]
    public int Suspcion;
    //amount suspicion meter must reach to make player lose
    
    public int LoseGame = 4;
    //number of jewels of selected type player must steal to win
    
    public int JewelTarget = 4;
    //type of jewel currently required to win (number player must steal defined by "JewelTarget"
    [HideInInspector]
    public string JewelType1;
    [HideInInspector]
    public string JewelType2;
    [HideInInspector]
    public string JewelType3;
    [HideInInspector]
    public string JewelType4;
    //public string[] JewelTypes;
    //number of jewels of selected type player has successfully stolen
    [HideInInspector]
    public int JewelsStolen;
    //type of jewel selected 
    [HideInInspector]
    public string[] JewelTags = {"red", "blue", "purple", "green"};

    //CameraIsOn is updated by the SecurityCamera script each time the camera swithces
    //on or off.
    [HideInInspector]
    public bool CameraIsOn;
    [HideInInspector]
    public bool Camera2IsOn;

    [HideInInspector]
    public int PlayerScore;
    public Text ScoreText;

    public Text ObjectiveText1;
    public Text ObjectiveText2;
    public Text ObjectiveText3;
    public Text ObjectiveText4;

    public GameObject SuspicionMeterPlaceHolder;

    //sound sources
    public GameObject SpecialScore;
    public GameObject SuccessSteal;
    public GameObject CamAlarm;
    public GameObject WinYay;
    public GameObject LoseMusic;

    [HideInInspector]
    public Scene CurrentScene;
    public string BonusScene = "SurvivalRound";

    public static int FinalScore;

    

    void Start()
    {
        CurrentScene = SceneManager.GetActiveScene();
        if (CurrentScene.name == BonusScene)
        {
            CameraIsOn = false;
            Camera2IsOn = false;
            Suspcion = 0;
            JewelsStolen = 0;
            PlayerScore = 0;
            JewelType1 = JewelTags[Random.Range(0, JewelTags.Length)];
            showObjective();
            updateScore();
            updateSuspicion();
        }
        else
        {
            CameraIsOn = false;
            Camera2IsOn = false;
            Suspcion = 0;
            JewelsStolen = 0;
            PlayerScore = 0;
            //random selection from JewelTags array for which jewel player needs to steal
            //in this round
            JewelType1 = JewelTags[Random.Range(0, JewelTags.Length)];
            JewelType2 = JewelTags[Random.Range(0, JewelTags.Length)];
            JewelType3 = JewelTags[Random.Range(0, JewelTags.Length)];
            JewelType4 = JewelTags[Random.Range(0, JewelTags.Length)];
            showObjective();
            updateScore();
            updateSuspicion();
        }
    }

    void Update()
    {
        
    }

    public void checkStolen(string whichJewel)
    {
        //script attached to container will call this function and provide int associated with 
        //jewel type thrown in stash bag; this method will check whether it should add a point toward win

        if (CameraIsOn == true || Camera2IsOn == true)
        {
            Suspcion += 1;
            CamAlarm.gameObject.GetComponent<AudioSource>().Play();
            Debug.Log("Suspicion: " + Suspcion);
            updateSuspicion();
            winOrLose();
        }
        else if (whichJewel == JewelType1 || whichJewel == JewelType2 || whichJewel == JewelType3 || whichJewel == JewelType4)
        {
            JewelsStolen += 1;
            SuccessSteal.gameObject.GetComponent<AudioSource>().Play();
            Debug.Log("Is this repeating?");
            //Debug.Log("Jewels Stolen: " + JewelsStolen);
            PlayerScore += 50;
            subtractJewelType(whichJewel);
            updateScore();
            winOrLose();
            
            if (CurrentScene.name == BonusScene)
            {
                JewelType1 = JewelTags[Random.Range(0, JewelTags.Length)];
                showObjective();
            }
        }
        else if (whichJewel == "special")
        {
            SpecialScore.gameObject.GetComponent<AudioSource>().Play();
            PlayerScore += 100;
            updateScore();
        }

        if(CurrentScene.name == BonusScene)
        {
            JewelsStolen = 0;
        }
        
        
    }

    public void winOrLose()
        //this method will be called each time the correct jewel is stolen, or when the player is caught stealing on 
        //camera and suspicion rises. It checks whether max suspicion is reached (i.e. game over), or the right jewels
        //are successfully stolen (i.e. win screen)
    {
        if(Suspcion == LoseGame)
        {
            FinalScore = PlayerScore;
            //LoseMusic.gameObject.GetComponent<AudioSource>().Play();
            StartCoroutine(delayLoseScreen());
            //SceneManager.LoadScene();
        }
        else if(JewelsStolen == JewelTarget)
        {
            FinalScore = PlayerScore;
            //WinYay.gameObject.GetComponent<AudioSource>().Play();
            StartCoroutine(delayWinScreen());
            //SceneManager.LoadScene();
        }

        IEnumerator delayLoseScreen()
        {
            yield return new WaitForSeconds(3);
            SceneManager.LoadScene("LossScreen");
        }


        IEnumerator delayWinScreen()
        {
            yield return new WaitForSeconds(2);
            SceneManager.LoadScene("WinScreen");
        }
    }

    public void updateScore()
    {
        string ScoreString = PlayerScore.ToString();
        ScoreText.text = ScoreString;
    }

    public void showObjective()
    {
        switch (JewelType1)
        {
            case "red":
                ObjectiveText1.text = "Red";
                break;
            case "blue":
                ObjectiveText1.text = "Blue";
                break;
            case "purple":
                ObjectiveText1.text = "Purple";
                break;
            case "green":
                ObjectiveText1.text = "Green";
                break;
        }
        switch (JewelType2)
        {
            case "red":
                ObjectiveText2.text = "Red";
                break;
            case "blue":
                ObjectiveText2.text = "Blue";
                break;
            case "purple":
                ObjectiveText2.text = "Purple";
                break;
            case "green":
                ObjectiveText2.text = "Green";
                break;
        }
        switch (JewelType3)
        {
            case "red":
                ObjectiveText3.text = "Red";
                break;
            case "blue":
                ObjectiveText3.text = "Blue";
                break;
            case "purple":
                ObjectiveText3.text = "Purple";
                break;
            case "green":
                ObjectiveText3.text = "Green";
                break;
        }
        switch (JewelType4)
        {
            case "red":
                ObjectiveText4.text = "Red";
                break;
            case "blue":
                ObjectiveText4.text = "Blue";
                break;
            case "purple":
                ObjectiveText4.text = "Purple";
                break;
            case "green":
                ObjectiveText4.text = "Green";
                break;
        }
    }

    public void subtractJewelType(string WhichJewelStolen)
    {
        if(WhichJewelStolen == JewelType1)
        {
            JewelType1 = "0";
            ObjectiveText1.text = "-----";
        }
        else if(WhichJewelStolen == JewelType2)
        {
            JewelType2 = "0";
            ObjectiveText2.text = "-----";
        }
        else if (WhichJewelStolen == JewelType3)
        {
            JewelType3 = "0";
            ObjectiveText3.text = "-----";
        }
        else if (WhichJewelStolen == JewelType4)
        {
            JewelType4 = "0";
            ObjectiveText4.text = "-----";
        }
    }

    public void updateSuspicion()
    {
        SuspicionMeterPlaceHolder.gameObject.GetComponent<SuspicionMeterScript>().setMeter(Suspcion);
    }

}
