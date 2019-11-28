using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrControlManager : MonoBehaviour
{
	public GameObject Controls, Pause;

    public void ToControl()
    {
        Controls.SetActive(true);
        Pause.GetComponent<scrPauseMenu>().Options = true;
        Pause.SetActive(false);
    }

    public void ToPause()
    {
        Pause.SetActive(true);
        Pause.GetComponent<scrPauseMenu>().Options = false; 
     	Controls.SetActive(false); 
    }
}
