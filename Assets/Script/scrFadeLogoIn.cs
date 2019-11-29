using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrFadeLogoIn : MonoBehaviour
{
    public GameObject Logo, Etec;

    public void Logos()
    {
        Logo.SetActive(true);
        Etec.SetActive(true);
    }
}
