using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrAudioManager : MonoBehaviour
{
    public bool Found, Stoped;
    public AudioSource Music;
    private GameObject [] Effects;
    void Update()
    {

        if(!Found){
            Effects = GameObject.FindGameObjectsWithTag("Effects");
            for (int i = 0; i < Effects.Length; i++)
            {
                Effects[i].GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("EffectVolum", 1);
            }
            Music.volume = PlayerPrefs.GetFloat("MusicVolum", 1);
        }
        else{
            Effects = GameObject.FindGameObjectsWithTag("Effects");
            if(!Stoped){
                for (int i = 0; i < Effects.Length; i++)
                {
                    Effects[i].GetComponent<AudioSource>().mute = true;
                    if(i == Effects.Length - 1){
                        Stoped = true;
                    }
                }
            }
        }
    }
}
