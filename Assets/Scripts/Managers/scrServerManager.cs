using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class scrServerManager : MonoBehaviour
{
	public int count;
	public bool Acabou = false, AcabouOTempo, Over;

	public GameObject Enemys, EnmyPrin;

    void FixedUpdate()
    {
		if(!AcabouOTempo || !Acabou){
			if(!Acabou){
				GameObject[] Servers = GameObject.FindGameObjectsWithTag("Server");
				for (int i = 0; i < Servers.Length; i++){
					if(Servers[i].GetComponent<scrDriver>().GetIt){
						count++;
					}
					if(i == Servers.Length - 1){
						if(count == Servers.Length){
							Acabou = true;
						}
						else{
							count = 0;
						}
					}
				}
			}
		}
		if(GetComponentInChildren<Slider>().maxValue == GetComponentInChildren<Slider>().value && !Acabou && !Over){
			AcabouOTempo = true;
			Over = true;
			GameObject.Find("MenuPause").GetComponent<scrPauseMenu>().enabled = false;
			GameObject Player = GameObject.Find("Player");
			Player.GetComponent<scrInterfaceItens>().enabled = false;
			Player.GetComponent<scrPlayer>().enabled = false;
			Player.GetComponent<Animator>().SetBool("Andando", false);
			Player.GetComponent<scrPlayerAim>().enabled = false;
			GameObject.Find("DeathManager").GetComponent<scrDeathManager>().Sender = EnmyPrin.gameObject;
			Enemys.SetActive(true);
			GameObject.Find("FollowCam").GetComponent<scrFollowCam>().PTFollow = EnmyPrin.gameObject;
			StartCoroutine(Wait());
		}
    }

	IEnumerator Wait(){
		yield return new WaitForSeconds(12f);
		GameObject.Find("DeathManager").GetComponent<scrDeathManager>().Death = true;
	}
}
