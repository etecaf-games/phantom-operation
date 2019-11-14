using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrBackToSaveMenu : MonoBehaviour
{
    public GameObject Menu;

	public void MenuPainel(){
		Menu.SetActive(true);
		gameObject.SetActive(false);
	}
}
