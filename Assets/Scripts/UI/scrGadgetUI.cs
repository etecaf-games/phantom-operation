using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class scrGadgetUI : MonoBehaviour
{
    void FixedUpdate()
    {
       GetComponent<TextMeshProUGUI>().text = GameObject.FindGameObjectWithTag("Player").GetComponent<scrInterfaceItens>().Gadgets.ToString();
    }
}
