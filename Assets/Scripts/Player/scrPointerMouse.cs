using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrPointerMouse : MonoBehaviour
{
	private Vector3 target;
	public GameObject Pointer;
	public bool isMenu;

    void Update()
    {
        if(isMenu){
        	target = transform.GetComponent<Camera>().ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z));
      	  	Pointer.transform.position = new Vector2(target.x, target.y);
        }
    }
}
