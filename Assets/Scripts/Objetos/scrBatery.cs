using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrBatery : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D quem)
    {
        if(quem.gameObject.tag == "Player"){
        	if(quem.gameObject.GetComponent<scrPlayer>().barras <= 4){
        		quem.gameObject.GetComponent<scrPlayer>().barras++;
        		quem.gameObject.GetComponent<scrPlayer>().TempoLuz = quem.gameObject.GetComponent<scrPlayer>().DuraçãoLuz;
        		Destroy(this.gameObject);
        	}
        }
    }
}
