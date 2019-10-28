using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class scrPauseMenu : MonoBehaviour
{
    public Slider Effect, Musica;
    public GameObject OptionsPanel, MenuPanel;
    private Animator animTela;
    public bool Ativado, Options;

    void Start()
    {
        animTela = GetComponent<Animator>();
    }

    public void OptionsMenu(){
        Options = true;
        OptionsPanel.SetActive(true);
        MenuPanel.SetActive(false);
        Musica.value = PlayerPrefs.GetFloat("MusicVolum", 1);
        Effect.value = PlayerPrefs.GetFloat("EffectVolum", 1);
    }

    public void ChangeEffect(){
        if(PlayerPrefs.HasKey("EffectVolum")){
            PlayerPrefs.DeleteKey("EffectVolum");
            PlayerPrefs.SetFloat("EffectVolum", Effect.value);
        }
        else{
            PlayerPrefs.SetFloat("EffectVolum", Effect.value);
        }
    }

    public void ChangeMusic(){
        if(PlayerPrefs.HasKey("MusicVolum")){
            PlayerPrefs.DeleteKey("MusicVolum");
            PlayerPrefs.SetFloat("MusicVolum", Musica.value);
        }
        else{
            PlayerPrefs.SetFloat("MusicVolum", Musica.value);
        }
    }

    public void BackMenu(){
        Options = false;
        OptionsPanel.SetActive(false);
        MenuPanel.SetActive(true);
    }

    public void StartMenu(){
        SceneManager.LoadScene("MenuInicial");
    }

    public void BackGame(){
        if(Ativado){
            Ativado = false;
            Time.timeScale = 1f;
        }
        else{
            Ativado = true;
            Time.timeScale = 0f;
        }
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
            if(!Options){
                if(Ativado){
                    Ativado = false;
                    Time.timeScale = 1f;
                }
                else{
                    Ativado = true;
                    Time.timeScale = 0f;
                }
            }
        }
        animTela.SetBool("Ativado", Ativado);
    }
}
