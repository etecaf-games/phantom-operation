using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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
        GameObject.FindGameObjectWithTag("Achiviment").GetComponentInChildren<TextMeshProUGUI>().text = "Você conseguiu um codigo";
        GameObject.FindGameObjectWithTag("Achiviment").GetComponent<Animator>().SetBool("Anime-se", true);
    }

    void OnTriggerExit2D(Collider2D quem) {
        if(quem.gameObject.tag == "Player"){
            Entrou = false;
            Player = null;
        }
    }
}
