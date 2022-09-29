using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplayScript : MonoBehaviour
{
    //public int GetFinalScore;
    public Text FinalScoreText;

    // Start is called before the first frame update
    void Start()
    {
        //GetFinalScore = Game_Manager.FinalScore;

        FinalScoreText.text = "Your Score: " + Game_Manager.FinalScore.ToString();
    }

}
