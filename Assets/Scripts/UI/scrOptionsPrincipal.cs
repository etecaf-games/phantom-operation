using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class scrOptionsPrincipal : MonoBehaviour
{
    public Slider Musica, Effect;
    public AudioSource Test;
    public void ChangeMusic(){
        if(PlayerPrefs.HasKey("MusicVolum")){
            PlayerPrefs.DeleteKey("MusicVolum");
            PlayerPrefs.SetFloat("MusicVolum", Musica.value);
        }
        else{
            PlayerPrefs.SetFloat("MusicVolum", Musica.value);
        }
    }

    public void ChangeEffect(){
        if(PlayerPrefs.HasKey("EffectVolum")){
            PlayerPrefs.DeleteKey("EffectVolum");
            PlayerPrefs.SetFloat("EffectVolum", Effect.value);
        }
        else{
            PlayerPrefs.SetFloat("EffectVolum", Effect.value);
        }
        Test.volume = Effect.value;
    }
}
