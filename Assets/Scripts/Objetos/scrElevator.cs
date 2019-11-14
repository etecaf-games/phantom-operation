using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class scrElevator : MonoBehaviour
{
	public string NextLevel, NomeIndice;
	public float FadeIn;
	public GameObject Fade, AudioManager, Loading;
	public bool GotIt, CallUnActiveHours;
	int coins, barras;
	void Update(){
		if(GotIt){
			GetComponent<Animator>().SetBool("Animese", true);
		}
	}

	void OnTriggerEnter2D(Collider2D quem){
		if(quem.gameObject.tag == "Player"){
			if(GotIt){
				GameObject Player = quem.gameObject;
				GameObject.Find("MenuPause").GetComponent<scrPauseMenu>().enabled = false;
				Player.GetComponent<scrInterfaceItens>().enabled = false;
				Player.GetComponent<scrPlayer>().enabled = false;
				Player.GetComponent<Animator>().SetBool("Andando", false);
				coins = Player.GetComponent<scrInterfaceItens>().Moedas;
				barras = Player.GetComponent<scrPlayer>().barras;
				Player.GetComponent<scrPlayerAim>().enabled = false;
				InvokeRepeating("InvokeToFade", 0.02f, 0.03f);
			}
		}
	}

	void InvokeToFade(){
		Fade.GetComponent<CanvasGroup>().alpha += FadeIn;
		if(!CallUnActiveHours){
			Fade.GetComponent<scrInitialFade>().enabled = false;
			Fade.GetComponentInChildren<TextMeshProUGUI>().gameObject.SetActive(false);
			AudioManager.GetComponent<scrAudioManager>().enabled = false;
			CallUnActiveHours = true;
		}
		AudioManager.GetComponent<AudioSource>().volume -= FadeIn;
		if(Fade.GetComponent<CanvasGroup>().alpha >= 1f){
			NomeIndice = GameObject.Find("LevelManager").GetComponent<scrLevelManager>().NomeIndice;
			PlayerPrefs.DeleteKey("NamePhaseOf" + NomeIndice);
            PlayerPrefs.SetString("NamePhaseOf" + NomeIndice, NextLevel);
            PlayerPrefs.DeleteKey("IndexCoinsOf" + NomeIndice);
            PlayerPrefs.SetInt("IndexCoinsOf" + NomeIndice, coins);
            PlayerPrefs.DeleteKey("CargaCoinsOf" + NomeIndice);
            PlayerPrefs.SetInt("CargaCoinsOf" + NomeIndice, barras);
            StartCoroutine(carregando());
		}
	}

	IEnumerator carregando()
    {
        AsyncOperation operacao = SceneManager.LoadSceneAsync(PlayerPrefs.GetString("NamePhaseOf" + NomeIndice, NextLevel));

        Loading.SetActive(true);
        while (!operacao.isDone)
        {
            yield return null;
        }
    }
}
