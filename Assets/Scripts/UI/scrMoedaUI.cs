using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class scrMoedaUI : MonoBehaviour
{    void Update()
    {
       GetComponent<TextMeshProUGUI>().text = GameObject.FindGameObjectWithTag("Player").GetComponent<scrInterfaceItens>().Moedas.ToString();
    }
}
