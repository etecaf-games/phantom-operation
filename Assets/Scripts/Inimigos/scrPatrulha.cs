﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrPatrulha : MonoBehaviour
{
	public AudioSource Passos;
	public float CouldDown;
	public bool FollowCoin, Andando;
	bool CoinAt;
	float Tempo;
	Rigidbody2D rbEnemy;
	public bool Mover, CallPassos;
	public float Velocidade, radius;
	public int Local;
	public Transform[] posições;
	scrRotation LookScript;
	public Vector3 LocalCoin;
	Animator AnimEnemy;

    void Start()
    {
    	rbEnemy = GetComponent<Rigidbody2D>();
    	AnimEnemy = GetComponent<Animator>();
		Vector3 PosFut = posições[Local].position;
        PosFut.z = 5f;
		PosFut.x -= transform.position.x;
        PosFut.y -= transform.position.y;
        float angle = Mathf.Atan2(PosFut.y, PosFut.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle));
		LookScript = GetComponent<scrRotation>();
    }

    void FixedUpdate()
    {
		if(!FollowCoin){
			Vector3 LocalDestino = posições[Local].position;
			Move(LocalDestino);
			Tempo = CouldDown;
		}
		AnimEnemy.SetBool("Andando", Andando);
		if(Vector2.Distance(transform.position, GameObject.Find("Player").transform.position) < radius){
			if(Andando){
				if(!CallPassos){
					CallPassos = true;
					Passos.Play();
				}
			}
			else{
				CallPassos = false;
				Passos.Stop();
			}
		}
		else{
			Passos.Stop();
		}
	}
	public void Move(Vector3 Destino){
		transform.position = Vector2.MoveTowards(transform.position, Destino, Velocidade * Time.deltaTime);
		if(transform.position == Destino){
			LookScript.RotaçãoDestino();
			Andando = false;
		}
		else{
			Andando = true;
		}
		if(Mover){
			LookScript.lerp = 0f;
			if(Local >= posições.Length - 1f){
				Local = 0;
			}
			else{
				Local++;
			}
			Mover = false;
		}
	}

	
}
