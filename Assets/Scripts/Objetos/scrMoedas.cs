using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class scrMoedas : MonoBehaviour
{
	public AudioSource Pick;
    void OnCollisionEnter2D(Collision2D quem)
    {
    	if(quem.gameObject.tag == "Player")
    	{
			Pick.Play();
    		quem.gameObject.GetComponent<scrInterfaceItens>().Moedas++;
			GameObject.FindGameObjectWithTag("Achiviment").GetComponentInChildren<TextMeshProUGUI>().text = "Voce consegiu uma moeda";
			GameObject.FindGameObjectWithTag("Achiviment").GetComponent<Animator>().SetBool("Anime-se", true);	
    		Destroy(gameObject);
    	}
    }
}
