using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrBattery : MonoBehaviour
{
    void Update()
    {
        GetComponent<Animator>().SetInteger("State", GameObject.FindGameObjectWithTag("Player").GetComponent<scrPlayer>().barras);
    }
}
