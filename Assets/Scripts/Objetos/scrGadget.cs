using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class scrGadget : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D quem)
    {
    	if(quem.gameObject.tag == "Player")
    	{
    		quem.gameObject.GetComponent<scrInterfaceItens>().Gadgets++;
			GameObject.FindGameObjectWithTag("Achiviment").GetComponentInChildren<TextMeshProUGUI>().text = "Você consegiu um dispositivo!";
			GameObject.FindGameObjectWithTag("Achiviment").GetComponent<Animator>().SetBool("Anime-se", true);	
    		Destroy(gameObject);
    	}
    }
}
