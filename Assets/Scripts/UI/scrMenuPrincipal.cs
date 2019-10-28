using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class scrMenuPrincipal : MonoBehaviour
{

    public GameObject MenuPrin, AboutUS, Options;
    public Slider Music, Effect;

    public void StartButton(){

    }

    public void OptionsMenu(){
        MenuPrin.SetActive(false);
        Options.SetActive(true);
        Music.value = PlayerPrefs.GetFloat("MusicVolum", 1);
        Effect.value = PlayerPrefs.GetFloat("EffectVolum", 1);
    }

    public void AboutUs(){
        MenuPrin.SetActive(false);
        AboutUS.SetActive(true);
    }

    public void Quit(){
        Application.Quit();
    }

    public void BackMenuOP(){
        if(PlayerPrefs.HasKey("MusicVolum")){
            PlayerPrefs.DeleteKey("MusicVolum");
            PlayerPrefs.SetFloat("MusicVolum", Music.value);
        }
        else{
            PlayerPrefs.SetFloat("MusicVolum", Music.value);
        }
        if(PlayerPrefs.HasKey("EffectVolum")){
            PlayerPrefs.DeleteKey("EffectVolum");
            PlayerPrefs.SetFloat("EffectVolum", Effect.value);
        }
        else{
            PlayerPrefs.SetFloat("EffectVolum", Effect.value);
        }
        MenuPrin.SetActive(true);
        Options.SetActive(false);
    }

    public void BackMenuAU(){
        MenuPrin.SetActive(true);
        AboutUS.SetActive(false);
    }
}
