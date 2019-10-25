using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class scrChat : MonoBehaviour
{
	public float delay = 0.1f, delayProx = 2f;
	public string[] Texto;
	public  bool digitando = true;
	public int indice;
	string LetraType;

    void Start()
    {
        StartCoroutine(Typing());
    }

    void FixedUpdate(){
    	if(!digitando && indice < Texto.Length - 1)
    	{
    		this.GetComponent<TextMeshProUGUI>().text = "";
    		LetraType = "";
    		indice++;
    		StartCoroutine(Typing());
    		digitando = true;
    	}
    	if(!digitando && indice < Texto.Length){
    		this.GetComponent<TextMeshProUGUI>().text = "";
    		this.GetComponentInParent<Animator>().SetBool("Finalizado", true);
    	}
    }

    IEnumerator Typing(){
    	for(int i = 0; i < Texto[indice].Length + 1; i++){
    		LetraType = Texto[indice].Substring(0,i);
    		this.GetComponent<TextMeshProUGUI>().text = LetraType;
    		yield return new WaitForSeconds(delay);
    	}
    	yield return new WaitForSeconds(delayProx);
    	digitando = false;
    }
}
