using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrTaunt : MonoBehaviour
{
	void Update()
    {
        GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("EffectVolum", 1);
    }
}
