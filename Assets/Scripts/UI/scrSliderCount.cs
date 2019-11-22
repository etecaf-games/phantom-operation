using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class scrSliderCount : MonoBehaviour
{
    void FixedUpdate()
    {
        if(!GetComponentInParent<scrServerManager>().Acabou){
            GetComponent<Slider>().value -= Time.deltaTime;
        }
    }
}
