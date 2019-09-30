using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrGadget : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D quem)
    {
    	if(quem.gameObject.tag == "Player")
    	{
    		quem.gameObject.GetComponent<scrInterfaceItens>().Gadgets++;
    		Destroy(gameObject);
    	}
    }
}
