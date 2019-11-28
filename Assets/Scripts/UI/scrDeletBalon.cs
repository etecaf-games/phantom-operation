using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrDeletBalon : MonoBehaviour
{
	public bool Instaciado, LastLevel, Item1, Item2;
	public GameObject Follower, Player, Iten1, Iten2;

    public void DestroyMe(){
    	if(Instaciado){
	    	GameObject.Find("MenuPause").GetComponent<scrPauseMenu>().enabled = true;
	    	Follower.GetComponent<scrFollowCam>().PTFollow = Player;
			GameObject.Find("PassosPlayer").GetComponent<AudioSource>().mute = false;
	    	Player.GetComponent<scrInterfaceItens>().enabled = true;
			Player.GetComponent<scrPlayer>().Andando = true;
			Player.GetComponent<scrPlayer>().enabled = true;
			Player.GetComponent<scrPlayerAim>().enabled = true;
			if(Item1){
				Iten1.SetActive(true);
			}
			if(Item2){
				Iten2.SetActive(true);
			}
		}
		if(LastLevel){
			GameObject.Find("ServerManager(Clone)").GetComponentInChildren<scrSliderCount>().enabled = true;
		}
    	Destroy(gameObject);
    }
}
