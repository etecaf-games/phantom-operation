using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class scrDeathManager : MonoBehaviour
{
    public float inLerp = 1f, Lerp = 0f, Additional;
    public bool Death;
    public Image DeathPanel, HUD;
    public GameObject FollowCam, Sender;
    void Update()
    {
        if(Death){
            FollowCam.GetComponent<scrFollowCam>().PTFollow = Sender;
            GameObject.Find("Player").GetComponent<scrPlayer>().enabled = false;
            GameObject.Find("Player").GetComponent<Animator>().SetBool("Andando", false);
            GameObject.Find("Player").GetComponent<scrPlayerAim>().enabled = false;
            GameObject.Find("Player").GetComponent<scrInterfaceItens>().enabled = false;
            HUD.GetComponent<CanvasGroup>().alpha = inLerp;
            DeathPanel.GetComponent<CanvasGroup>().alpha = Lerp;
            if(Lerp != 1){
                Lerp += Additional;
            }
            if(inLerp != 0){
                inLerp -= Additional;
            }
            Vector3 PosFut = GameObject.Find("Player").transform.position;
            if(Sender.transform.position == FollowCam.transform.position && DeathPanel.GetComponent<CanvasGroup>().alpha == 1){
                Time.timeScale = 0f;
            }
        }
    }
}
