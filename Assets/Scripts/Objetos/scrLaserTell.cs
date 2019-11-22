using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class scrLaserTell : MonoBehaviour
{
    public AudioSource Destivado;
    public string[] Dialogs;
    public GameObject Chat, Timer, Canvas, Follower, enmys, enmyPrin;
    void OnTriggerEnter2D(Collider2D quem){
        if(quem.gameObject.tag == "Player"){


            GameObject.Find("MenuPause").GetComponent<scrPauseMenu>().enabled = false;
			GameObject Player = GameObject.Find("Player");
			Player.GetComponent<scrInterfaceItens>().enabled = false;
			GameObject.Find("PassosPlayer").GetComponent<AudioSource>().mute = true;
            Player.GetComponent<scrPlayer>().enabled = false;
			Player.GetComponent<Animator>().SetBool("Andando", false);
			Player.GetComponent<scrPlayerAim>().enabled = false;


            GameObject b = Instantiate(Timer, new Vector3(-461.8802f, -259.8076f, 0), Quaternion.identity);
            b.GetComponentInChildren<scrSliderCount>().enabled = false;
            b.GetComponentInChildren<Slider>().value = 80;
            b.transform.SetParent(Canvas.transform ,false);
            b.GetComponent<scrServerManager>().Enemys = enmys;
            b.GetComponent<scrServerManager>().EnmyPrin = enmyPrin;


            GameObject a = Instantiate(Chat, new Vector3(40, 80, 0), Quaternion.identity) as GameObject;
            a.transform.SetParent(Canvas.transform ,false);
            a.GetComponent<scrDeletBalon>().Instaciado = true;
            a.GetComponent<scrDeletBalon>().LastLevel = true;
            a.GetComponent<scrDeletBalon>().Player = quem.gameObject;
            a.GetComponentInChildren<scrChat>().Texto = Dialogs;
            a.GetComponent<scrDeletBalon>().Follower = Follower;
            a.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);

            Destivado.Play();

            Destroy(gameObject);
        }
    }
}
