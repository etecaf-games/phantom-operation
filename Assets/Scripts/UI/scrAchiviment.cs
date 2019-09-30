using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrAchiviment : MonoBehaviour
{
    public void Back(){
        GetComponent<Animator>().SetBool("Anime-se", false);
    }
}
