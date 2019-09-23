using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrPlayer : MonoBehaviour
{   
    #region Variaveis de Ativação de Luz

    public bool Andando;
    public bool InputadoLuz;
    public bool Acesa;
    public float couldownIncialLuz;
    public float couldownLuz;
    public GameObject Lanterna;
    Animator AnimPlayer;

    #endregion

    #region Variaveis de movimento horizontal

    public float Velocidade;

    #endregion

    void Start()
    {
    	Acesa = true;
        AnimPlayer = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        #region Movimentação Horizontal

        if(Input.GetKey(KeyCode.A)){
            transform.Translate(Vector3.left * Velocidade * Time.deltaTime, Space.World);
            Andando = true;
        }

        if(Input.GetKey(KeyCode.D)){
            transform.Translate(Vector3.right * Velocidade * Time.deltaTime, Space.World);
            Andando = true;
        }

        if(Input.GetKey(KeyCode.S)){
            transform.Translate(Vector3.down * Velocidade * Time.deltaTime, Space.World);
            Andando = true;
        }

        if(Input.GetKey(KeyCode.W)){
            transform.Translate(Vector3.up * Velocidade * Time.deltaTime, Space.World);
            Andando = true;

        }

        if(Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.A)){
            Andando = false;
        }

        if(!(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A))){
            Andando = false;
        }

        AnimPlayer.SetBool("Andando", Andando);

        #endregion

        #region Ativação Luz

        if(Input.GetKeyDown(KeyCode.F) && couldownLuz <= 0)
        {
            InputadoLuz = true;
            couldownLuz = couldownIncialLuz;
        	Acesa = !Acesa;
        	Lanterna.SetActive(Acesa);

        }

        if(couldownLuz > 0)
        {
            couldownLuz -= Time.deltaTime;
        }

        #endregion
    }
}
