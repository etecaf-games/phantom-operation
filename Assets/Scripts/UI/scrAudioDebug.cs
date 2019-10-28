using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class scrAudioDebug : MonoBehaviour
{
    public void PlayDebug(){
        GetComponent<AudioSource>().volume = GetComponent<Slider>().value;
        GetComponent<AudioSource>().Play();
    }
}
