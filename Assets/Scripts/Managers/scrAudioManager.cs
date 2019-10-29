using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrAudioManager : MonoBehaviour
{
    public AudioSource Music;
    private GameObject [] Effects;
    void Update()
    {
        Effects = GameObject.FindGameObjectsWithTag("Effects");
        for (int i = 0; i < Effects.Length; i++)
        {
            Effects[i].GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("EffectVolum", 1);
        }
        Music.volume = PlayerPrefs.GetFloat("MusicVolum", 1);
    }
}
