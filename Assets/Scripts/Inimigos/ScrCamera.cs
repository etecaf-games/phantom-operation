using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrCamera : MonoBehaviour
{
    public float velocidadeRot = 1.5f, radius;
    Rigidbody2D rbEnemy;
    int index = 0;
    public GameObject[] Limites;
    float angulo, z, lerp, rotationIF, anguloIF;

	void Update () {
		rbEnemy = GetComponent<Rigidbody2D>();
        Vector3 PosFut = Limites[index].transform.position;
        PosFut.z = 5f;
		PosFut.x -= transform.position.x;
        PosFut.y -= transform.position.y;
        angulo = Mathf.Atan2(PosFut.y, PosFut.x) * Mathf.Rad2Deg;
        rotationIF = float.Parse(rbEnemy.rotation.ToString("N4"));
        anguloIF = float.Parse(angulo.ToString("N4"));
        Rotação(angulo);
        if(rotationIF == anguloIF || rotationIF == anguloIF * -1){
        	lerp = 0;
            index++;
            if(index >= Limites.Length){
            	index = 0;
            }
        }
        if(Vector2.Distance(GameObject.FindGameObjectWithTag("Player").transform.position, transform.position) <= radius){
            GetComponent<AudioSource>().mute = false;
        }
        else{
            GetComponent<AudioSource>().mute = true;
        }
    }
    public void Rotação(float angulo){
        Quaternion rotacao = transform.rotation;
        z = rotacao.eulerAngles.z;
        lerp += Time.deltaTime / velocidadeRot;
        z = Mathf.LerpAngle(z, angulo, lerp);
        rotacao = Quaternion.Euler(0, 0, z);
        transform.rotation = rotacao;
    }
}
