using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrDriver : MonoBehaviour
{
	public GameObject Player, Exclamacao;

	public bool entrou, GetIt, Called;

    void FixedUpdate()
    {
        if(entrou && Input.GetKey(KeyCode.E) && !Called){
        	GameObject b = Instantiate(Exclamacao) as GameObject;
        	b.transform.position = Player.transform.position;
        	b.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
        	GetIt = true;
        	Called = true;
        }
    }

    void OnTriggerEnter2D(Collider2D quem)
    {
        if(quem.gameObject.tag == "Player"){
        	entrou = true;
        	Player = quem.gameObject;
        }
    }

    void OnTriggerExit2D(Collider2D quem)
    {
        if(quem.gameObject.tag == "Player"){
        	entrou = false;
        	Player = null;
        }
    }
}
