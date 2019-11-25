using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrNuvemManager : MonoBehaviour
{
    public GameObject Nuvem;
    bool Perm;
    float tempo;
    void Start()
    {
        GameObject b = Instantiate(Nuvem) as GameObject;
        b.transform.position = transform.position;
        b.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
        tempo = Random.Range(5, 10);
        Perm = false;
        StartCoroutine(Instancia());
    }

    void Update()
    {
        if(Perm){
            Perm = false;
            StartCoroutine(Instancia());
        }
    }

    IEnumerator Instancia(){
        yield return new WaitForSeconds(tempo);
        GameObject b = Instantiate(Nuvem) as GameObject;
        b.transform.position = transform.position;
        b.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
        Perm = true;
    }
}
