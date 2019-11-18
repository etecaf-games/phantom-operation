using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrArmario : MonoBehaviour
{
    public string[] Dialogs;
    public GameObject Elevator, Chat, Canvas, Player, Follower;
    public bool Entrou, Resgatado, Animado;
    Animator animArmario;

    void Start()
    {
        animArmario = GetComponent<Animator>();
    }
    void FixedUpdate()
    {
        if(Input.GetKeyDown(KeyCode.E) && Entrou && !Animado){
            Elevator.GetComponent<scrElevator>().GotIt = true;
            Resgatado = true;
            Animado = true;
        }
        animArmario.SetBool("Resgatado",Resgatado);
    }

    void OnTriggerEnter2D(Collider2D quem) {
        if(quem.gameObject.tag == "Player"){
            Entrou = true;
            Player = quem.gameObject;
        }
    }

    public void Animando(){
        Resgatado = false;
        GetComponentInChildren<AudioSource>().Play();
        GameObject a = Instantiate(Chat, new Vector3(40, 80, 0), Quaternion.identity) as GameObject;
        a.transform.SetParent(Canvas.transform ,false);
        a.GetComponent<scrDeletBalon>().Instaciado = true;
        a.GetComponent<scrDeletBalon>().Player = Player;
        a.GetComponentInChildren<scrChat>().Texto = Dialogs;
        a.GetComponent<scrDeletBalon>().Follower = Follower;
        a.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
        //GameObject.FindGameObjectWithTag("Achiviment").GetComponent<Animator>().SetBool("Anime-se", true);
    }

    void OnTriggerExit2D(Collider2D quem) {
        if(quem.gameObject.tag == "Player"){
            Entrou = false;
            Player = null;
        }
    }
}
