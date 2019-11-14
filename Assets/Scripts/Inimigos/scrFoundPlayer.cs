using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrFoundPlayer : MonoBehaviour
{
    public float z;
    public float DuraçãoRot;
    public float lerp;
    public AudioSource FoundPlayer;
    
    float angulo;
    Rigidbody2D rbEnemy;
    scrPatrulha PatrulaScript;
    public int DestinoVisão;
    void Start()
    {
        
    }
    void FixedUpdate()
    {
        Vector3 PosFut = GameObject.Find("Player").transform.position;
        PosFut.z = 5f;
		PosFut.x -= transform.position.x;
        PosFut.y -= transform.position.y;
        angulo = Mathf.Atan2(PosFut.y, PosFut.x) * Mathf.Rad2Deg;
        Rotação(angulo);
        if(float.Parse(angulo.ToString("N4")) == float.Parse(GetComponent<Rigidbody2D>().rotation.ToString("N4")) || float.Parse(angulo.ToString("N4")) == float.Parse(GetComponent<Rigidbody2D>().rotation.ToString("N4")) * -1f){
            Time.timeScale = 0f;
        }
    }

    public void Rotação(float angulo){
        Quaternion rotacao = transform.rotation;
        z = rotacao.eulerAngles.z;
        lerp += Time.deltaTime / DuraçãoRot;
        z = Mathf.LerpAngle(z, angulo, lerp);
        rotacao = Quaternion.Euler(0, 0, z);
        transform.rotation = rotacao;
    }
}
