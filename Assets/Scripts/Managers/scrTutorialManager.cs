using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrTutorialManager : MonoBehaviour
{
	public int LvlTutorial;
	public bool NeedFollowOfIndex, Item1, Item2;
	public int Index;
	public string[] Chat;
	public GameObject Follower, Follow, Player, BallonChat, Canvas, Iten1, Iten2;
	GameObject b;

	void Start(){
		string NomeIndice = GameObject.Find("LevelManager").GetComponent<scrLevelManager>().NomeIndice;
		if(PlayerPrefs.HasKey("Tutorial" + LvlTutorial + NomeIndice)){
			Debug.Log("Tutorial" + LvlTutorial + NomeIndice);
			Debug.Log(PlayerPrefs.GetString("Tutorial" + LvlTutorial + NomeIndice, "corno"));
			Destroy(gameObject);
		}
	}

	void OnTriggerEnter2D(Collider2D quem){
		if(quem.gameObject.tag == "Player"){
			Player = quem.gameObject;
			string NomeIndice = GameObject.Find("LevelManager").GetComponent<scrLevelManager>().NomeIndice;
			PlayerPrefs.SetString("Tutorial" + LvlTutorial + NomeIndice, "got");
			GameObject.Find("MenuPause").GetComponent<scrPauseMenu>().enabled = false;
			Player.GetComponent<scrInterfaceItens>().enabled = false;
			Player.GetComponent<scrPlayer>().enabled = false;
			Player.GetComponent<Animator>().SetBool("Andando", false);
			Player.GetComponent<scrPlayerAim>().enabled = false;
			InstacieOBalão();
		}
	}

	void InstacieOBalão(){
		b = Instantiate(BallonChat, new Vector3(0, 80, 0), Quaternion.identity) as GameObject;
		b.transform.SetParent(Canvas.transform ,false);
		if(Item1){
			Iten1.SetActive(false);
			b.GetComponent<scrDeletBalon>().Item1 = true;
			b.GetComponent<scrDeletBalon>().Iten1 = Iten1;	
		}
		if(Item2){
			Iten2.SetActive(false);
			b.GetComponent<scrDeletBalon>().Item2 = true;
			b.GetComponent<scrDeletBalon>().Iten2 = Iten2;
		}
		b.GetComponentInChildren<scrChat>().Texto = Chat;
        b.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
        InvokeRepeating("AskFollow", 0.02f, 0.03f);
	}

	void AskFollow(){
		if(NeedFollowOfIndex){
        	if(b.GetComponentInChildren<scrChat>().indice == Index){
        		Follower.GetComponent<scrFollowCam>().PTFollow = Follow;
        	}
        	if(b.GetComponentInChildren<scrChat>().indice == Chat.Length - 2){
        		b.GetComponent<scrDeletBalon>().Instaciado = true;
        		b.GetComponent<scrDeletBalon>().Follower = Follower;
        		b.GetComponent<scrDeletBalon>().Player = Player;
        		Destroy(gameObject);
        		CancelInvoke();
        	}
        }
	}

}
