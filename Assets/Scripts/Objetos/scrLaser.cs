using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class scrLaser : MonoBehaviour
{
    public float radius;
    public AudioSource srcLaserEffect, srcLaserEffectDesactive, srcLaserBurn;
    public bool desativado;

    void Start(){
    }

    void Update(){
        if(desativado)
        {
            if(Vector2.Distance(GameObject.FindGameObjectWithTag("Player").transform.position, transform.position) <= radius){
                srcLaserEffect.mute = false;
            }
            else{
                srcLaserEffect.mute = true;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D quem) {
        if(quem.gameObject.tag == "Player"){
            srcLaserBurn.Play();
            GameObject.FindGameObjectWithTag("DeathManager").GetComponent<scrDeathManager>().Sender = this.gameObject;
            GameObject.FindGameObjectWithTag("DeathManager").GetComponent<scrDeathManager>().Death = true;
        }
        if(quem.gameObject.tag == "Moeda Lançada"){
            Destroy(quem.gameObject);
            srcLaserBurn.Play();
        }
        if(quem.gameObject.tag == "Gadget"){
            desativado = false;
            srcLaserEffect.Stop();
            srcLaserEffectDesactive.Play();
            Destroy(quem.gameObject);
            Destroy(gameObject);
        }
        if(quem.gameObject.tag == "Batery"){
            Destroy(quem.gameObject);
            srcLaserBurn.Play();
        }
    }
}
