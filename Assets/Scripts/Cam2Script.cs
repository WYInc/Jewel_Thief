using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam2Script : MonoBehaviour
{
    public GameObject Camera;
    public GameObject Game_Manager;
    public float CamInterval = 3f;
    private float Timer = 0f;

    private bool CameraOn;

    //sound
    public GameObject CamBeep;

    // Update is called once per frame
    void Update()
    {
        if (Timer >= CamInterval)
        {

            toggleOnOff();
            Timer = 0f;

        }
        else
        {
            Timer = Timer + Time.deltaTime;
        }
    }

    void toggleOnOff()
    {
        if (CameraOn == false)
        {
            CamBeep.gameObject.GetComponent<AudioSource>().Play();
            Camera.GetComponent<MeshRenderer>().material.EnableKeyword("_EMISSION");
            Game_Manager.gameObject.GetComponent<Game_Manager>().Camera2IsOn = true;
            CameraOn = true;
        }
        else
        {
            CamBeep.gameObject.GetComponent<AudioSource>().Play();
            Camera.GetComponent<MeshRenderer>().material.DisableKeyword("_EMISSION");
            Game_Manager.gameObject.GetComponent<Game_Manager>().Camera2IsOn = false;
            CameraOn = false;
        }
    }
}
