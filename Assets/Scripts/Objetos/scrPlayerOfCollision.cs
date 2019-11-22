using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrPlayerOfCollision : MonoBehaviour
{
	public GameObject Exclamacao;
    void OnCollisionEnter2D(Collision2D quem)
    {
 		if(quem.gameObject.tag == "Player"){
 			if(!quem.gameObject.GetComponent<scrPlayer>().Acesa){
 				GameObject b = Instantiate(Exclamacao) as GameObject;
        		b.transform.position = quem.gameObject.transform.position;
        		b.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
 			}
 		}       
    }
}
