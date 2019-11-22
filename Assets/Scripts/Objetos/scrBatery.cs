using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class scrBatery : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D quem)
    {
        if(quem.gameObject.tag == "Player"){
        	if(quem.gameObject.GetComponent<scrPlayer>().barras <= 4){
        		quem.gameObject.GetComponent<scrPlayer>().barras++;
        		quem.gameObject.GetComponent<scrPlayer>().TempoLuz = quem.gameObject.GetComponent<scrPlayer>().DuraçãoLuz;
                GameObject.FindGameObjectWithTag("Achiviment").GetComponentInChildren<TextMeshProUGUI>().text = "Você conseguiu uma bateria";
			    GameObject.FindGameObjectWithTag("Achiviment").GetComponent<Animator>().SetBool("Anime-se", true);	
        		Destroy(this.gameObject);
        	}
        }
    }
}
