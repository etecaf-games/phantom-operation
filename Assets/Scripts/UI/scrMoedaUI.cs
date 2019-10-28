using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class scrMoedaUI : MonoBehaviour
{   void FixedUpdate()
    {
       GetComponent<TextMeshProUGUI>().text = GameObject.FindGameObjectWithTag("Player").GetComponent<scrInterfaceItens>().Moedas.ToString();
    }
}
