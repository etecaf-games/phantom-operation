using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class scrGadgetUI : MonoBehaviour
{
    void Update()
    {
       GetComponent<TextMeshProUGUI>().text = GameObject.FindGameObjectWithTag("Player").GetComponent<scrInterfaceItens>().Gadgets.ToString();
    }
}
