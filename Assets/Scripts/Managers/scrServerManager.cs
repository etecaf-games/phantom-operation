using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrServerManager : MonoBehaviour
{
	public int count;
	public bool Acabou = false;

    void Start()
    {
        
    }

    void FixedUpdate()
    {
    	if(!Acabou){
	        GameObject[] Servers = GameObject.FindGameObjectsWithTag("Server");
	        for (int i = 0; i < Servers.Length; i++){
	            if(Servers[i].GetComponent<scrDriver>().GetIt){
	            	count++;
	            }
	            if(i == Servers.Length - 1){
	            	if(count == Servers.Length){
	            		Acabou = true;
		            }
		            else{
		            	count = 0;
		            }
	            }
	        }
    	}
    }
}
