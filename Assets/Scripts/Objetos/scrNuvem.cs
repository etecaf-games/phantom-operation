using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrNuvem : MonoBehaviour
{
    SpriteRenderer spNuv;
    public float velocidade;

    void Start()
    {
        spNuv = GetComponent<SpriteRenderer>();
        int order = Random.Range(-1, 1);
        if(order == 0){
            order = 1;
        }
        spNuv.sortingOrder = order;
        velocidade = Random.Range(4,10);
        float scale = Random.Range(0.5f,1);
        transform.localScale = new Vector3(scale,scale,scale);
    }

    void FixedUpdate()
    {
        if(!spNuv.isVisible){
            StartCoroutine(CountAgain());
        }

        transform.position = new Vector3(transform.position.x - velocidade * Time.deltaTime, transform.position.y, transform.position.z);

    }

    IEnumerator CountAgain(){
        yield return new WaitForSeconds(7f);
        if(!spNuv.isVisible){
            Destroy(gameObject);
        }
    }
}
