using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrSaveManager : MonoBehaviour
{
	public GameObject Save, Load, ManiMenu, Me;

	public void LoadPainel(){
		Load.SetActive(true);
		gameObject.SetActive(false);
	}

	public void SavePainel(){
		Save.SetActive(true);
		gameObject.SetActive(false);
	}

	public void MainPainel(){
		ManiMenu.SetActive(true);
		Me.SetActive(false);
	}
}
