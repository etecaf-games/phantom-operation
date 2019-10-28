using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class scrSliderTurnOff : MonoBehaviour
{
    public Slider slid;
    public Image X;

    void Update()
    {
        if(slid.value == 0){
            X.enabled = true;
        }else{
            X.enabled = false;
        }
        
    }
}
