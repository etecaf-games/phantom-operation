using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class scrDeathManager : MonoBehaviour
{
    public float inLerp = 1f, Lerp = 0f, Additional;
    public bool Death, Tocado;
    public Image DeathPanel, HUD;
    public GameObject FollowCam, Sender;
    public AudioSource FoundSound;
    void Awake(){
        Time.timeScale = 1f;
    }

    void Update()
    {
        if(Death){
            transform.position = FollowCam.transform.position;
            FollowCam.GetComponent<scrFollowCam>().PTFollow = Sender;
            GameObject.Find("Player").GetComponent<scrPlayer>().enabled = false;
            GameObject.Find("Player").GetComponent<Animator>().SetBool("Andando", false);
            GameObject.Find("Player").GetComponent<scrPlayerAim>().enabled = false;
            GameObject.Find("Player").GetComponent<scrInterfaceItens>().enabled = false;
            HUD.GetComponent<CanvasGroup>().alpha = inLerp;
            DeathPanel.GetComponent<CanvasGroup>().alpha = Lerp;
            if(Lerp <= 1){
                Lerp += Additional;
            }
            if(inLerp >= 0){
                inLerp -= Additional;
            }
            else{
                HUD.gameObject.SetActive(false);
            }
            if(Sender.gameObject.name == "Inimigo 1"){
                if(!Tocado){
                    Sender.gameObject.transform.GetChild(3).gameObject.SetActive(true);
                    Destroy(Sender.gameObject.transform.GetChild(2).gameObject);
                    FoundSound.Play();
                    Tocado = true;
                }
            }
            Vector3 PosFut = GameObject.Find("Player").transform.position;
            GameObject.Find("AudioManager").GetComponent<scrAudioManager>().Found = true;
        }
    }
}
