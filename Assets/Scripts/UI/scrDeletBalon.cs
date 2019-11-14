using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrDeletBalon : MonoBehaviour
{
	public bool Instaciado;
	public GameObject Follower, Player;

    public void DestroyMe(){
    	if(Instaciado){
	    	GameObject.Find("MenuPause").GetComponent<scrPauseMenu>().enabled = true;
	    	Follower.GetComponent<scrFollowCam>().PTFollow = Player;
	    	Player.GetComponent<scrInterfaceItens>().enabled = true;
			Player.GetComponent<scrPlayer>().Andando = true;
			Player.GetComponent<scrPlayer>().enabled = true;
			Player.GetComponent<scrPlayerAim>().enabled = true;
		}
    	Destroy(gameObject);
    }
}
