using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrFOVMoeda : MonoBehaviour
{
    public float viewRadius = 5;

    public float viewAngle = 115;

    public LayerMask obstacleMask, detectionMask;

    public Collider2D[] targetsInRadius;

    public List<Transform> visibleTargets = new List<Transform>();

    private void Update()
    {
        FindVisibleTargets();
    }

    void FindVisibleTargets()
    {
        targetsInRadius = Physics2D.OverlapCircleAll(transform.position, viewRadius, detectionMask, -Mathf.Infinity, Mathf.Infinity);
        visibleTargets.Clear();
        
        for (int i = 0; i < targetsInRadius.Length; i++)
        {
            Transform target = targetsInRadius[i].transform;
            Vector2 dirTarget = new Vector2(target.position.x - transform.position.x, target.position.y - transform.position.y);
            Vector2 dir = new Vector2();
            dir = transform.right;
            Debug.DrawLine(transform.position, target.position, Color.green);

            if (Vector2.Angle(dirTarget, dir) < viewAngle / 2)
            {
                float distanceTarget = Vector2.Distance(transform.position, target.position);
                if (!Physics2D.Raycast(transform.position, dirTarget, distanceTarget, obstacleMask))
                {
                    visibleTargets.Add(target);
                    Debug.DrawLine(transform.position, target.position, Color.red);
                    if(target.gameObject.tag == "Moeda Lançada"){
                    	GetComponent<ScrFOV>().MoedaVista = true;
                    	GetComponent<ScrFOV>().Moeda = target.gameObject;
                    }
                    else{
                    	GetComponent<ScrFOV>().MoedaVista = false;
                    	GetComponent<ScrFOV>().Moeda = null;
                    }
                }
            }
        }
    }
}
