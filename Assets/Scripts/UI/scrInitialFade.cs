using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrInitialFade : MonoBehaviour
{
    void Update()
    {
        GetComponent<CanvasGroup>().alpha -= 0.02f;
    }
}
