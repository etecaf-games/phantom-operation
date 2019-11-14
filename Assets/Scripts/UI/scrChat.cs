using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class scrChat : MonoBehaviour
{
    public AudioSource Tap;
    public Animator Falando;
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
            Tap.Play();
    		yield return new WaitForSeconds(delay);
            if(Input.GetButton("Jump")){
                i = Texto[indice].Length - 2; 
            }
            Falando.SetBool("Talking", true);
    	}
        Falando.SetBool("Talking", false);
    	yield return new WaitForSeconds(delayProx);
    	digitando = false;
    }
}
