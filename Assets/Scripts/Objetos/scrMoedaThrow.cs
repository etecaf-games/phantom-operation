using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrMoedaThrow : MonoBehaviour
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
}
