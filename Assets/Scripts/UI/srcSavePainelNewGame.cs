using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class srcSavePainelNewGame : MonoBehaviour
{
    bool Over, Called;
    public GameObject NoneCount, Loading;
    public float FadeInOut, Increase;
	public string NomeIndice, WhatCall;    
    public CanvasGroup Tela, Fade;
	public TextMeshProUGUI Fase, Moedas, Carga;

    void Start()
    {
        if(!PlayerPrefs.HasKey("NamePhaseOf" + NomeIndice)){
        	gameObject.SetActive(true);
        }
        else{
        	gameObject.SetActive(false);
            NoneCount.GetComponent<scrShowNone>().Count++;
        }
        Fase.text = PlayerPrefs.GetString("NamePhaseOf" + NomeIndice, "None");
        Moedas.text = "Coins: " + PlayerPrefs.GetInt("IndexCoinsOf" + NomeIndice, 0);
        Carga.text = "Charges: " + PlayerPrefs.GetInt("CargaCoinsOf" + NomeIndice, 0);
    }

    public void NewGameCreate()
    {
        if(Over){            
            if(PlayerPrefs.HasKey("NomeIndice")){
                PlayerPrefs.DeleteKey("NomeIndice");
                PlayerPrefs.SetString("NomeIndice", NomeIndice);
            }
            else{
                PlayerPrefs.SetString("NomeIndice", NomeIndice);
            }
            if(PlayerPrefs.HasKey("NamePhaseOf" + NomeIndice)){
                PlayerPrefs.DeleteKey("NamePhaseOf" + NomeIndice);
                PlayerPrefs.SetString("NamePhaseOf" + NomeIndice, "CutScene1");
            }
            else{
                PlayerPrefs.SetString("NamePhaseOf" + NomeIndice, "CutScene1");
            }
            if(PlayerPrefs.HasKey("IndexCoinsOf" + NomeIndice)){
                PlayerPrefs.DeleteKey("IndexCoinsOf" + NomeIndice);
                PlayerPrefs.SetInt("IndexCoinsOf" + NomeIndice, 0);
            }
            else{
               PlayerPrefs.SetInt("IndexCoinsOf" + NomeIndice, 0);
            }
            if(PlayerPrefs.HasKey("CargaCoinsOf" + NomeIndice)){
                PlayerPrefs.DeleteKey("CargaCoinsOf" + NomeIndice);
                PlayerPrefs.SetInt("CargaCoinsOf" + NomeIndice, 5);
            }
            else{
               PlayerPrefs.SetInt("CargaCoinsOf" + NomeIndice, 5);
            }
            if(PlayerPrefs.HasKey("Tutorial Move" + NomeIndice)){
                PlayerPrefs.DeleteKey("Tutorial Move" + NomeIndice);
            }
            if(PlayerPrefs.HasKey("Tutorial" + 1 + NomeIndice)){
                PlayerPrefs.DeleteKey("Tutorial" + 1 + NomeIndice);
            }
            if(PlayerPrefs.HasKey("Tutorial" + 2 + NomeIndice)){
                PlayerPrefs.DeleteKey("Tutorial" + 2 + NomeIndice);
            }
            if(PlayerPrefs.HasKey("Tutorial" + 3 + NomeIndice)){
                PlayerPrefs.DeleteKey("Tutorial" + 3 + NomeIndice);
            }
            if(PlayerPrefs.HasKey("Tutorial" + 4 + NomeIndice)){
                PlayerPrefs.DeleteKey("Tutorial" + 4 + NomeIndice);
            }
            if(PlayerPrefs.HasKey("Tutorial" + 5 + NomeIndice)){
                PlayerPrefs.DeleteKey("Tutorial" + 5 + NomeIndice);
            }
            if(PlayerPrefs.HasKey("Tutorial" + 6 + NomeIndice)){
                PlayerPrefs.DeleteKey("Tutorial" + 6 + NomeIndice);
            }
            StartCoroutine(carregando());
        }
        else{
            if(!Called){
                InvokeRepeating("InvokeFade", 0.02f, 0.03f);
            }            
            WhatCall = "NewGameCreate";
            Debug.Log("Acessado");
        }
    }

    IEnumerator carregando()
    {
        AsyncOperation operacao = SceneManager.LoadSceneAsync(PlayerPrefs.GetString("NamePhaseOf" + NomeIndice, "Level 1"));

        Loading.SetActive(true);
        while (!operacao.isDone)
        {
            yield return null;
        }
    }

    void InvokeFade(){
        FadeInOut += Increase;
        GameObject.Find("AudioManager").GetComponent<scrAudioManager>().enabled = false;
        GameObject.Find("AudioManager").GetComponent<AudioSource>().volume -= FadeInOut;
        Fade.alpha = FadeInOut;
        Fade.blocksRaycasts = true;
        Tela.blocksRaycasts = false;
        Tela.alpha = 1f - FadeInOut;
        if(FadeInOut >= 1){
            Over = true;
            CancelInvoke();
            Invoke(WhatCall, 0.02f);
            Debug.Log("Over");
        }
    }
}
