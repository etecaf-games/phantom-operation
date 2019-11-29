using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class scrLoadSceneFinal : MonoBehaviour
{
	public GameObject Loading;
    public void LoadMenu()
    {
        string NomeIndice = PlayerPrefs.GetString("NomeIndice", "DENs");
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
        StartCoroutine(Load());
    }
   	
    IEnumerator Load(){
    	AsyncOperation operacao = SceneManager.LoadSceneAsync("Menu");

        Loading.SetActive(true);
        while (!operacao.isDone)
        {
            yield return null;
        }
    }
}
