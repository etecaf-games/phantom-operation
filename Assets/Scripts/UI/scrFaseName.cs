using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class scrFaseName : MonoBehaviour
{
	bool Apareceu;
	float Lerp;
    void Update()
    {
        Scene scene = SceneManager.GetActiveScene();
        GetComponent<TextMeshProUGUI>().text = scene.name;
        if(!Apareceu){
        	Lerp = GetComponent<CanvasGroup>().alpha;
        	Lerp += 0.02f;
        	GetComponent<CanvasGroup>().alpha = Lerp;
        	if(GetComponent<CanvasGroup>().alpha == 1){
        		Apareceu = true;
        	}
        }
        else{
        	Lerp = GetComponent<CanvasGroup>().alpha;
        	Lerp -= 0.02f;
        	GetComponent<CanvasGroup>().alpha = Lerp;
        	if(GetComponent<CanvasGroup>().alpha == 0){
        		Destroy(gameObject);
        	}
        }
    }
}
