using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrPatrulha : MonoBehaviour
{
	public AudioSource Passos, FoundSound;
	public float CouldDown;
	public bool FollowCoin, Andando, FoundPlayer;
	bool CoinAt;
	float Tempo;
	Rigidbody2D rbEnemy;
	public bool Mover, CallPassos, LastLevel;
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
		if(Vector2.Distance(GameObject.Find("Player").transform.position, transform.position) <= 1){
            GameObject.FindGameObjectWithTag("DeathManager").GetComponent<scrDeathManager>().Sender = this.gameObject;
            GameObject.FindGameObjectWithTag("DeathManager").GetComponent<scrDeathManager>().Death = true;
            GetComponent<scrFoundPlayer>().enabled = true;
            GetComponent<scrPatrulha>().FoundPlayer = true;
            GetComponent<scrPatrulha>().enabled = false;
		}
		AnimEnemy.SetBool("Andando", Andando);
		if(!FoundPlayer){
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
			if(!LastLevel){
				LookScript.lerp = 0f;
				if(Local >= posições.Length - 1f){
					Local = 0;
				}
				else{
					Local++;
				}
				Mover = false;
				
			}
			else{
				LookScript.lerp = 0f;
				if(Local >= posições.Length - 2f){
					GetComponent<scrPatrulha>().enabled = false;
				}
				else{
					Local++;
				}
				Mover = false;
			}
		}
	}	
}
