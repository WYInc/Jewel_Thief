using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuspicionMeterScript : MonoBehaviour
{
    public Transform PlaceHolderTransform;

    public GameObject Meter0;
    public GameObject Meter1;
    public GameObject Meter2;
    public GameObject Meter3;
    public GameObject Meter4;
    public GameObject Meter5;

    public void setMeter(int WhichMeter)
    {
        switch (WhichMeter)
        {
            case 0:
                Instantiate(Meter0, PlaceHolderTransform);
                
                break;
            case 1:
                Instantiate(Meter1, PlaceHolderTransform);
                break;
            case 2:
                Instantiate(Meter2, PlaceHolderTransform);
                break;
            case 3:
                Instantiate(Meter3, PlaceHolderTransform);
                break;
            case 4:
                Instantiate(Meter4, PlaceHolderTransform);
                break;
            case 5:
                Instantiate(Meter5, PlaceHolderTransform);
                break;

        }
     
    }


}
