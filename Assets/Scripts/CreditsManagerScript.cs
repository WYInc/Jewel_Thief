using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsManagerScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(delaySceneForCredits());
    }

    IEnumerator delaySceneForCredits()
    {
        yield return new WaitForSeconds(6);
        SceneManager.LoadScene("StartMenu");
    }


}
