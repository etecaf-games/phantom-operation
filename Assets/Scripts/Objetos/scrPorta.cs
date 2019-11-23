using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrPorta : MonoBehaviour
{
	public bool aberto, area;
	public float HoldRotation, lerp, DuracaoRot;

 	void Start(){
 		Quaternion rotacao = transform.rotation;
        HoldRotation = rotacao.eulerAngles.z;
 	}

    void FixedUpdate()
    {
    	if(!aberto){
	        if(Input.GetKeyDown(KeyCode.E)	&& area){
	        	lerp = 0;
	        	CancelInvoke();
	        	InvokeRepeating("RotaçãoSoma", 0.02f, 0.03f);
	        	aberto = true;
	        }
	    }else{
	        if(Input.GetKeyDown(KeyCode.E) && area){
	        	lerp = 0;
	        	CancelInvoke();
	        	InvokeRepeating("RotaçãoSub", 0.02f, 0.03f);
	        	aberto = false;
	        }
	    }
    }

    public void RotaçãoSoma(){
        Quaternion rotacao = transform.rotation;
        float z = rotacao.eulerAngles.z;
        lerp += Time.deltaTime / DuracaoRot;
        z = Mathf.LerpAngle(z, HoldRotation + 90, lerp);
        rotacao = Quaternion.Euler(0, 0, z);
        transform.rotation = rotacao;
        if(z == HoldRotation + 90){
        	CancelInvoke();
        }
    }

    public void RotaçãoSub(){
        Quaternion rotacao = transform.rotation;
        float z = rotacao.eulerAngles.z;
        lerp += Time.deltaTime / DuracaoRot;
        z = Mathf.LerpAngle(z, HoldRotation, lerp);
        rotacao = Quaternion.Euler(0, 0, z);
        transform.rotation = rotacao;
        if(z == HoldRotation){
        	CancelInvoke();
        }
    }

    void OnTriggerEnter2D(Collider2D quem){
    	if(quem.gameObject.tag == "Player"){
    		area = true;
    	}
    }

    void OnTriggerExit2D(Collider2D quem){
    	if(quem.gameObject.tag == "Player"){
    		area = false;
    	}
    }
}