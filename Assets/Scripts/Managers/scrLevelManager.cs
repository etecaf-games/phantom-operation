using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrLevelManager : MonoBehaviour
{
	public int Coins, barras;
	public string NomeIndice, NomeDaFase;
	public GameObject Player;

    void Awake()
    {
    	NomeIndice = PlayerPrefs.GetString("NomeIndice", "Crash");
      Player.GetComponent<scrPlayer>().barras = PlayerPrefs.GetInt("CargaCoinsOf" + NomeIndice, 5);
      barras = PlayerPrefs.GetInt("CargaCoinsOf" + NomeIndice, 5);
    	NomeDaFase = PlayerPrefs.GetString("NamePhaseOf" + NomeIndice, "Oporra kkkk");
      Player.GetComponent<scrInterfaceItens>().Moedas = PlayerPrefs.GetInt("IndexCoinsOf" + NomeIndice, 0); 
      Coins = PlayerPrefs.GetInt("IndexCoinsOf" + NomeIndice, 9999);
    }
}
