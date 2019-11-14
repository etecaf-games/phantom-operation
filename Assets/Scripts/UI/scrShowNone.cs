using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrShowNone : MonoBehaviour
{
	public int Count;
	public GameObject Text;

    void Update()
    {
        if(Count == 3){
        	Text.SetActive(true);
        }
        else{
        	Text.SetActive(false);	
        }
    }
}
