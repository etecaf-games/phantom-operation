using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrFOVLuz : MonoBehaviour
{
    public GameObject Luz;

    ScrFOVLuzPlayer ScriptPlayer;

    public LayerMask obstacleMask, detectionMask;

    public Collider2D[] targetsInRadius;

    public List<Transform> visibleTargets = new List<Transform>();

    void Start(){
    	ScriptPlayer = GetComponent<ScrFOVLuzPlayer>();
    }
    
    private void Update()
    {
        FindVisibleTargets();

    }

    void FindVisibleTargets()
    {
        targetsInRadius = Physics2D.OverlapCircleAll(transform.position, ScriptPlayer.viewRadius, detectionMask, -Mathf.Infinity, Mathf.Infinity);
        visibleTargets.Clear();

        for (int i = 0; i < targetsInRadius.Length; i++)
        {
            Transform target = targetsInRadius[i].transform;
            Vector2 dirTarget = new Vector2(target.position.x - transform.position.x, target.position.y - transform.position.y);
            Vector2 dir = new Vector2();
            dir = transform.right;
            Debug.DrawLine(transform.position, target.position, Color.green);

            if (Vector2.Angle(dirTarget, dir) < ScriptPlayer.viewAngle / 2)
            {
                float distanceTarget = Vector2.Distance(transform.position, target.position);
                if (!Physics2D.Raycast(transform.position, dirTarget, distanceTarget, obstacleMask))
                {
                    visibleTargets.Add(target);
                    if(target.gameObject.tag == "LuzPlayer"){
                        Luz = target.gameObject;
                        InvokeRepeating("Actived", 0f, 0.02f);
                    }
                }
            }
        }
    }


    public void Actived(){
        if(Luz.gameObject.activeInHierarchy){
            ScriptPlayer.VistoLuz = true;
        }
        else{
            ScriptPlayer.VistoLuz = false;
        }
    }

    public Vector2 DirFromAngle(float angleDeg, bool global)
    {
        if (!global)
        {
            angleDeg += transform.eulerAngles.z;
        }
        return new Vector2(Mathf.Cos(angleDeg * Mathf.Deg2Rad), Mathf.Sin(angleDeg * Mathf.Deg2Rad));
    }
}
