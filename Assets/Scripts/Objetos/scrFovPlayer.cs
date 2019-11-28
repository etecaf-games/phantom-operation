using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrFovPlayer : MonoBehaviour
{	
	public GameObject Player;
	Animator AnimLuz;
    void Start()
    {
        AnimLuz = GetComponent<Animator>();
    }
    void Update()
    {
        AnimLuz.SetBool("Ligado", Player.GetComponent<scrPlayer>().Acesa);
    }
}
