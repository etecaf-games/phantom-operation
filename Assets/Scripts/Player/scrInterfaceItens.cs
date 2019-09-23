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
	public GameObject Moeda;
	public GameObject Incio;
	public int Moedas;
    void FixedUpdate()
    {
    	target = cam.transform.GetComponent<Camera>().ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z));

    	Vector3 difference = target - transform.position;
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;

        if(Input.GetKeyDown(KeyCode.Z) && Moedas >= 1 && tempo <= 0)
        {
            tempo = Couldown;
        	float distance = difference.magnitude;
            Vector2 direction = difference / distance;
            direction.Normalize();
            fireBullet(direction, rotationZ);
            Moedas--;	
        }
        tempo -= Time.deltaTime;
    }

    void fireBullet(Vector2 direction, float rotationZ){
        GameObject b = Instantiate(Moeda) as GameObject;
        b.transform.position = Incio.transform.position;
        b.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);
        b.GetComponent<Rigidbody2D>().velocity = direction * MoedaVelocidade;
    }
}
