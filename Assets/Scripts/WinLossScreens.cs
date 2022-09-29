using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinLossScreens : MonoBehaviour
{
    public string newGameScene;
    // Start is called before the first frame update
    
    public string SurvivalRound;
    
    public string Cam2Round;

    public void ChangeScene()
    {
        SceneManager.LoadScene(newGameScene);
    }
    public void QuitGame()
    {
        Application.Quit();
    }

    public void loadSurvival()
    {
        SceneManager.LoadScene(SurvivalRound);
    }

    public void load2Cam()
    {
        SceneManager.LoadScene(Cam2Round);
    } 
    
}
