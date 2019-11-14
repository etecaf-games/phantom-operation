using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class scrDeathPanel : MonoBehaviour
{
	public Button Reloader;
	public bool Turn;
	public Image fade;
	float LerpIN;

	public void Reload(){
		Turn = true;
		Reloader.interactable = false;
	}

	void Update(){
		if(Turn){
			LerpIN += 0.02f;
	        fade.GetComponent<CanvasGroup>().alpha = LerpIN;
	        GameObject.FindGameObjectWithTag("Music").GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("MusicVolum", 1) - LerpIN;
	        if(LerpIN >= 1){
	        	Scene scene = SceneManager.GetActiveScene();
	        	SceneManager.LoadScene(scene.name);
	        }
        }
	}

    void Lerp()
    {
    	LerpIN += 0.002f;
        fade.GetComponent<CanvasGroup>().alpha = LerpIN;
        GameObject.FindGameObjectWithTag("Music").GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("MusicVolum", 1) - LerpIN;
        if(LerpIN >= 1){
        	Scene scene = SceneManager.GetActiveScene();
        	SceneManager.LoadScene(scene.name);
        }
    }
}
