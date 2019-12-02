using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class scrSavePainel : MonoBehaviour
{
    bool Over, Called;
    public GameObject NoneCount, NoneCountNew, Respectivo, Loading;
    public AudioSource Delet;
    public float FadeInOut, Increase;
	public string NomeIndice, WhatCall;    
    public CanvasGroup Tela, Fade;
	public TextMeshProUGUI Fase, Moedas, Carga;

    void Start()
    {
        if(!PlayerPrefs.HasKey("NamePhaseOf" + NomeIndice)){
        	gameObject.SetActive(false);
            NoneCount.GetComponent<scrShowNone>().Count++;
        }
        Fase.text = PlayerPrefs.GetString("NamePhaseOf" + NomeIndice, "None");
        Moedas.text = "Coins: " + PlayerPrefs.GetInt("IndexCoinsOf" + NomeIndice, 0);
        Carga.text = "Charges: " + PlayerPrefs.GetInt("CargaCoinsOf" + NomeIndice, 0);
    }

    public void LoadGameAlreadyExist(){
        if(Over){
            if(PlayerPrefs.HasKey("NomeIndice")){
                PlayerPrefs.DeleteKey("NomeIndice");
                PlayerPrefs.SetString("NomeIndice", NomeIndice);
            }
           else{
               PlayerPrefs.SetString("NomeIndice", NomeIndice);
            }
            Debug.Log("Load");
            StartCoroutine(carregando());
        }
        else{
            if(!Called){
                InvokeRepeating("InvokeFade", 0.02f, 0.03f);
            }            
            WhatCall = "LoadGameAlreadyExist";
            Debug.Log("Acessado");
        }
    }

    public void DeletGame(){
        Delet.Play();
        PlayerPrefs.DeleteKey("NomeIndice");
        PlayerPrefs.DeleteKey("NamePhaseOf" + NomeIndice);
        PlayerPrefs.DeleteKey("IndexCoinsOf" + NomeIndice);
        PlayerPrefs.DeleteKey("CargaCoinsOf" + NomeIndice);
        PlayerPrefs.DeleteKey("Tutorial Move" + NomeIndice);
        PlayerPrefs.DeleteKey("Tutorial" + 1 + NomeIndice);
        PlayerPrefs.DeleteKey("Tutorial" + 2 + NomeIndice);
        PlayerPrefs.DeleteKey("Tutorial" + 3 + NomeIndice);
        PlayerPrefs.DeleteKey("Tutorial" + 4 + NomeIndice);
        PlayerPrefs.DeleteKey("Tutorial" + 5 + NomeIndice);
        PlayerPrefs.DeleteKey("Tutorial" + 6 + NomeIndice);
        PlayerPrefs.DeleteKey("Tutorial" + 7 + NomeIndice);
        PlayerPrefs.DeleteKey("Tutorial" + 8 + NomeIndice);
        Respectivo.SetActive(true);
        Respectivo.GetComponent<srcSavePainelNewGame>().Fase.text = PlayerPrefs.GetString("NamePhaseOf" + NomeIndice, "None");
        Respectivo.GetComponent<srcSavePainelNewGame>().Moedas.text = "Coins: " + PlayerPrefs.GetInt("IndexCoinsOf" + NomeIndice, 0);
        Respectivo.GetComponent<srcSavePainelNewGame>().Carga.text = "Charges: " + PlayerPrefs.GetInt("CargaCoinsOf" + NomeIndice, 0);
        NoneCount.GetComponent<scrShowNone>().Count++;
        NoneCountNew.GetComponent<scrShowNone>().Count--;
        gameObject.SetActive(false);
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
