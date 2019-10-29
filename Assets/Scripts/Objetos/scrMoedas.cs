using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrMoedas : MonoBehaviour
{
	public AudioSource Pick;
    void OnCollisionEnter2D(Collision2D quem)
    {
    	if(quem.gameObject.tag == "Player")
    	{
			Pick.Play();
    		quem.gameObject.GetComponent<scrInterfaceItens>().Moedas++;
    		Destroy(gameObject);
    	}
    }
}
