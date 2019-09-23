using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrFadeAmbient : MonoBehaviour
{
	scrPlayer scriptPlayer;
	public Color[] Claridades;
	public SpriteRenderer LuzAmbient;
	scrPlayer ScriptLuz;
	public float taxaTransicao;
	public bool Condicao;
	public bool InputPermitido;

    void Start()
    {
        scriptPlayer = GetComponent<scrPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
    	Condicao = scriptPlayer.Acesa;
    	InputPermitido = scriptPlayer.InputadoLuz;
        
        if(Condicao && InputPermitido)
        {
        	scriptPlayer.InputadoLuz = false;
        	Debug.Log("Input");
        	fadeIn();
        }
        if(!Condicao && InputPermitido)
        {
        	scriptPlayer.InputadoLuz = false;
        	Debug.Log("Input");
        	fadeOut();	
        }
    }

    public void Escurecer()
    {
        if (taxaTransicao >= 1f)
        {
            CancelInvoke("Escurecer");

        }
        LuzAmbient.color = Color.Lerp(Claridades[0], Claridades[1], taxaTransicao);
        taxaTransicao += 0.05f;

    }

    public void Clarear()
    {
        if (taxaTransicao >= 1f)
        {
            CancelInvoke("Clarear");
        }
        LuzAmbient.color = Color.Lerp(Claridades[1], Claridades[0], taxaTransicao);
        taxaTransicao += 0.05f;
    }

    public void fadeIn()
    {
        taxaTransicao = 0f;
        InvokeRepeating("Escurecer", 0f, 0.02f);
    }

    public void fadeOut()
    {
        taxaTransicao = 0f;
        InvokeRepeating("Clarear", 0f, 0.05f);
    }
}
