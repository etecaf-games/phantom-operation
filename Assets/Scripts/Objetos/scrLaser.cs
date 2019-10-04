using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class scrLaser : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D quem) {
        if(quem.gameObject.tag == "Player"){
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        if(quem.gameObject.tag == "Moeda Lançada"){
            Destroy(quem.gameObject);
        }
        if(quem.gameObject.tag == "Gadget"){
            Destroy(quem.gameObject);
            Destroy(gameObject);
        }
        if(quem.gameObject.tag == "Batery"){
            Destroy(quem.gameObject);
        }
    }
}
