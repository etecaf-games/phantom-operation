using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrInitialFade : MonoBehaviour
{
	public bool delete;

    void Update()
    {
        GetComponent<CanvasGroup>().alpha -= 0.008f;
        if(GetComponent<CanvasGroup>().alpha == 1 && delete){
        	Destroy(gameObject.GetComponent<scrInitialFade>());
        }
    }
}
