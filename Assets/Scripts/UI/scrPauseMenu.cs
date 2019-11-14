using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class scrPauseMenu : MonoBehaviour
{
    bool TOFade;
    public CanvasGroup Fade, Hud;
    public Slider Effect, Musica;
    public GameObject OptionsPanel, MenuPanel, AudioManager, Loading;
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


    public void LoadMenu(){
        TOFade = true;
    }

    public void BackMenu(){
        Options = false;
        OptionsPanel.SetActive(false);
        MenuPanel.SetActive(true);
    }

    IEnumerator carregando()
    {
        AsyncOperation operacao = SceneManager.LoadSceneAsync("Menu");

        Loading.SetActive(true);
        while (!operacao.isDone)
        {
            yield return null;
        }
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

        if(TOFade){
            GameObject[] Effects = GameObject.FindGameObjectsWithTag("Effects");
            for (int i = 0; i < Effects.Length; i++)
            {
                Effects[i].GetComponent<AudioSource>().volume -= 0.05f;
            }
            AudioManager.GetComponent<scrAudioManager>().enabled = false;
            AudioManager.GetComponent<AudioSource>().volume -= 0.05f;
            Hud.interactable = false;
            Fade.alpha += 0.05f;
            Time.timeScale = 0f;
            if(Fade.alpha >= 1){
                StartCoroutine(carregando());
            }
        }
    }
}
