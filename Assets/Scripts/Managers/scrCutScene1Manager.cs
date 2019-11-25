using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class scrCutScene1Manager : MonoBehaviour
{
    bool Call1, call2, call3;
    public GameObject Fade, Chat, loading, AudioEffect, Musica;
    void Start()
    {
    }
    void Update()
    {
        if(Fade.GetComponent<CanvasGroup>().alpha == 0 && !Call1){
            Call1 = true;
            Destroy(Fade.GetComponent<scrInitialFade>());
            Chat.SetActive(true);
        }
        if(Chat == null){
            Fade.GetComponent<CanvasGroup>().alpha += 0.008f;
            if(!call3){
                Musica.GetComponent<scrAudioManager>().enabled = false;
                call3 = true;
            }
            Musica.GetComponent<AudioSource>().volume -= 0.008f;
            AudioEffect.GetComponent<AudioSource>().volume -= 0.008f;
            if(Fade.GetComponent<CanvasGroup>().alpha == 1 && !call2){
                call2 = true;
                StartCoroutine(LoadScene());
            }
        }
    }

    IEnumerator LoadScene(){
        string NomeIndice = PlayerPrefs.GetString("NomeIndice", "trallei");
        if(PlayerPrefs.HasKey("NamePhaseOf" + NomeIndice)){
            PlayerPrefs.DeleteKey("NamePhaseOf" + NomeIndice);
            PlayerPrefs.SetString("NamePhaseOf" + NomeIndice, "1º Andar");
        }
        else{
            PlayerPrefs.SetString("NamePhaseOf" + NomeIndice, "1º Andar");
        }

        AsyncOperation operacao = SceneManager.LoadSceneAsync(PlayerPrefs.GetString("NamePhaseOf" + NomeIndice, "1º Andar"));

        loading.SetActive(true);
        while (!operacao.isDone)
        {
            yield return null;
        }
    }
}
