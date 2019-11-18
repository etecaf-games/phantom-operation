using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class scrGadgetThrow : MonoBehaviour
{
    Rigidbody2D rbMoeda;
    public float Pausa;

    public AudioSource Bip;
    public bool CallBip;
    public float radius;

    void Start()
    {
        rbMoeda = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
    	rbMoeda.drag = Pausa;
        rbMoeda.rotation = 0f;

        if(Vector2.Distance(transform.position, GameObject.Find("Player").transform.position) < radius){
            if(!CallBip){
                Bip.Play();
                CallBip = true;
            }
        }
        else{
                CallBip = false;
                Bip.Stop();
            }
    }
    void OnCollisionEnter2D(Collision2D quem)
    {
    	if(quem.gameObject.tag == "Player")
    	{
    		quem.gameObject.GetComponent<scrInterfaceItens>().Gadgets++;
            GameObject.FindGameObjectWithTag("Achiviment").GetComponentInChildren<TextMeshProUGUI>().text = "Voce consegiu um Gadget";
			GameObject.FindGameObjectWithTag("Achiviment").GetComponent<Animator>().SetBool("Anime-se", true);	
    		Destroy(gameObject);
    	}
    }
}
