using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrGadgetThrow : MonoBehaviour
{
    Rigidbody2D rbMoeda;
    public float Pausa;

    void Start()
    {
        rbMoeda = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
    	rbMoeda.drag = Pausa;
        rbMoeda.rotation = 0f;
    }
    void OnCollisionEnter2D(Collision2D quem)
    {
    	if(quem.gameObject.tag == "Player")
    	{
    		quem.gameObject.GetComponent<scrInterfaceItens>().Gadgets++;
    		Destroy(gameObject);
    	}
    }
}
