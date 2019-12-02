using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class scrServerManager : MonoBehaviour
{
	public GameObject Chat, Canvas, b, Fade, Loading;
	public int count;
	public bool Acabou = false, AcabouOTempo, Over, Call1, Call2;

	public GameObject Enemys, EnmyPrin;

	public string[] Chats;

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
		else
		if(0 == GetComponentInChildren<Slider>().value && !Acabou && !Over){
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

		if(Acabou && !Call1){
			GameObject.Find("MenuPause").GetComponent<scrPauseMenu>().enabled = false;
			GameObject Player = GameObject.Find("Player");
			Player.GetComponent<scrInterfaceItens>().enabled = false;
			GameObject.Find("PassosPlayer").GetComponent<AudioSource>().mute = true;
            Player.GetComponent<scrPlayer>().enabled = false;
			Player.GetComponent<Animator>().SetBool("Andando", false);
			Player.GetComponent<scrPlayerAim>().enabled = false;
			b = Instantiate(Chat, new Vector3(0, 80, 0), Quaternion.identity) as GameObject;
			b.transform.SetParent(Canvas.transform ,false);
			Fade.GetComponentInChildren<TextMeshProUGUI>().gameObject.SetActive(false);
			b.GetComponentInChildren<scrChat>().Texto = Chats;
			b.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
			Call1 = true;
		}

		if(b == null && Call1){
			//GetComponentInChildren<Slider>().gameObject.SetActive(false);
			Fade.GetComponent<CanvasGroup>().alpha += 0.08f;
			if(Fade.GetComponent<CanvasGroup>().alpha == 1 && !Call2){
				string NomeIndice = GameObject.Find("LevelManager").GetComponent<scrLevelManager>().NomeIndice;
				PlayerPrefs.DeleteKey("NamePhaseOf" + NomeIndice);
            	PlayerPrefs.SetString("NamePhaseOf" + NomeIndice, "Cutscene2");
				StartCoroutine(carregando());
				Call2 = true;
			}
		}
    }

	IEnumerator carregando()
    {
        AsyncOperation operacao = SceneManager.LoadSceneAsync(PlayerPrefs.GetString("NamePhaseOf" + GameObject.Find("LevelManager").GetComponent<scrLevelManager>().NomeIndice, "Cutscene2"));

        Loading.SetActive(true);
        while (!operacao.isDone)
        {
            yield return null;
        }
    }

	IEnumerator Wait(){
		yield return new WaitForSeconds(7f);
		GameObject.Find("DeathManager").GetComponent<scrDeathManager>().Death = true;
	}
}
