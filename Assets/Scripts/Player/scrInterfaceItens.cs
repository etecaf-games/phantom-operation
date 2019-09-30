using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrInterfaceItens : MonoBehaviour
{
	public Camera cam;
	private Vector3 target;
    public float Couldown;
    float tempo;

	public float MoedaVelocidade;
	public GameObject Moeda, Gadget;
	public GameObject Incio;
	public int Moedas, Gadgets;
    void FixedUpdate()
    {
    	target = cam.transform.GetComponent<Camera>().ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z));

    	Vector3 difference = target - transform.position;
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;

        if(Input.GetButtonDown("Fire1") && Moedas >= 1 && tempo <= 0)
        {
            tempo = Couldown;
        	float distance = difference.magnitude;
            Vector2 direction = difference / distance;
            direction.Normalize();
            fireCoin(direction, rotationZ);
            Moedas--;	
        }
        if(Input.GetButtonDown("Fire2") && Gadgets >= 1 && tempo <= 0){
            tempo = Couldown;
            float distance = difference.magnitude;
            Vector2 direction = difference / distance;
            direction.Normalize();
            fireGadget(direction, rotationZ);
            Gadgets--;
        }
        tempo -= Time.deltaTime;
    }

    void fireCoin(Vector2 direction, float rotationZ){
        GameObject b = Instantiate(Moeda) as GameObject;
        b.transform.position = Incio.transform.position;
        b.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);
        b.GetComponent<Rigidbody2D>().velocity = direction * MoedaVelocidade;
    }

    void fireGadget(Vector2 direction, float rotationZ){
        GameObject b = Instantiate(Gadget) as GameObject;
        b.transform.position = Incio.transform.position;
        b.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);
        b.GetComponent<Rigidbody2D>().velocity = direction * MoedaVelocidade;
    }
}
