using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrCheckMoveTutorial : MonoBehaviour
{
	public string NomeIndice;
    public GameObject Follower, Player;

    void Start()
    {
    	NomeIndice = GameObject.Find("LevelManager").GetComponent<scrLevelManager>().NomeIndice;
        if(PlayerPrefs.HasKey("Tutorial Move" + NomeIndice)){
        	Destroy(gameObject);
            GameObject.Find("MenuPause").GetComponent<scrPauseMenu>().enabled = true;
            Follower.GetComponent<scrFollowCam>().PTFollow = Player;
            Player.GetComponent<scrInterfaceItens>().enabled = true;
            Player.GetComponent<scrPlayer>().Andando = true;
            Player.GetComponent<scrPlayer>().enabled = true;
            Player.GetComponent<scrPlayerAim>().enabled = true;

        }
        else{
        	PlayerPrefs.SetInt("Tutorial Move" + NomeIndice, 0);
        }
    }
}
