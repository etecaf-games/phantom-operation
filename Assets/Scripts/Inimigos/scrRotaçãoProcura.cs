using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrRotaçãoProcura : MonoBehaviour
{

    public float rotationIF;
    public float anguloIF;
    public float z;
    public float DuraçãoRot;
    public float lerp;
    float angulo;
    Rigidbody2D rbEnemy;
    scrPatrulha PatrulaScript;
    public int DestinoVisão;
    
    void Start() {
        PatrulaScript = GetComponent<scrPatrulha>();
        rbEnemy = GetComponent<Rigidbody2D>();
    }
    public void RotaçãoDestino(){
        if(PatrulaScript.Local >= PatrulaScript.posições.Length - 1){
			DestinoVisão = 0;
		}
		else{
			DestinoVisão = PatrulaScript.Local + 1;
		}
        Vector3 PosFut = PatrulaScript.posições[DestinoVisão].position;
        PosFut.z = 5f;
		PosFut.x -= transform.position.x;
        PosFut.y -= transform.position.y;
        angulo = Mathf.Atan2(PosFut.y, PosFut.x) * Mathf.Rad2Deg;
        rotationIF = rbEnemy.rotation;
        anguloIF = float.Parse(angulo.ToString("N4"));
        Rotação();
        if(rotationIF == anguloIF){
            PatrulaScript.Mover = true;
        }
    }
    void Rotação(){
        Quaternion rotacao = transform.rotation;
        z = rotacao.eulerAngles.z;
        lerp += Time.deltaTime / DuraçãoRot;
        z = Mathf.LerpAngle(z, angulo, lerp);
        rotacao = Quaternion.Euler(0, 0, z);
        transform.rotation = rotacao;
    }
}
