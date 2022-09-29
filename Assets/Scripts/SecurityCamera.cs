using UnityEngine;
using UnityEngine.UI;

public class SecurityCamera : MonoBehaviour
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
            Game_Manager.gameObject.GetComponent<Game_Manager>().CameraIsOn = true;
            CameraOn = true;
        }
        else
        {
            CamBeep.gameObject.GetComponent<AudioSource>().Play();
            Camera.GetComponent<MeshRenderer>().material.DisableKeyword("_EMISSION");
            Game_Manager.gameObject.GetComponent<Game_Manager>().CameraIsOn = false;
            CameraOn = false;
        }
    }

}