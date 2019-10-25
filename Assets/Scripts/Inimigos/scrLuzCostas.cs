using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrLuzCostas : MonoBehaviour
{
	Vector3 PosFut;
	Animator AnimEnemy;
	Rigidbody2D rbEnemy;
	float angulo, Tempo;
	public bool rodado, AlreadyGet, AlreadyAcesa, Active;
	public float rotationIF;
    public float anguloIF;
    public float z;
    public float DuraçãoRot;
    public float lerp, Couldown;
    Transform target;

    public float viewRadius = 5;
    public float viewAngle = 115;

    public LayerMask obstacleMask, detectionMask;

    public Collider2D[] targetsInRadius;

    public List<Transform> visibleTargets = new List<Transform>();

    private void Start(){
    	rbEnemy = GetComponent<Rigidbody2D>();
    	AnimEnemy = GetComponent<Animator>();
    }
    
    private void Update()
    {        
        FindVisibleTargets();
    }

    void FindVisibleTargets()
    {
        targetsInRadius = Physics2D.OverlapCircleAll(transform.position,
            viewRadius,
            detectionMask,
            -Mathf.Infinity,
            Mathf.Infinity);

        visibleTargets.Clear();

        for (int i = 0; i < targetsInRadius.Length; i++)
        {
            
            target = targetsInRadius[i].transform;

            Vector2 dirTarget = new Vector2(target.position.x - transform.position.x, target.position.y - transform.position.y);
            Vector2 dir = new Vector2();
            dir = -transform.right;

            if (Vector2.Angle(dirTarget, dir) < viewAngle / 2)
            {
                float distanceTarget = Vector2.Distance(transform.position, target.position);

                if (!Physics2D.Raycast(transform.position, dirTarget, distanceTarget, obstacleMask))
                {
                    Active = true;
                    visibleTargets.Add(target);
                }
            }
        }
        if(Active){
                if(target.CompareTag("Player") && (target.gameObject.GetComponent<scrPlayer>().Acesa || AlreadyAcesa)){
                GetComponent<scrPatrulha>().enabled = false;
                GetComponent<ScrFOVMoeda>().enabled = false;
                GetComponent<scrRotation>().enabled = false;
                AlreadyAcesa = true;    
                if(rodado){
                    if(Vector2.Distance(transform.position, target.position) <= 0.5f){
                        Debug.Log("PARADEBUGARGAY");
                    }
                    if(Tempo <= 0){
                        int DestinoVisão = GetComponent<scrRotation>().DestinoVisão;
                        PosFut = GetComponent<scrPatrulha>().posições[DestinoVisão].position;
                        PosFut.z = 5f;
                        PosFut.x -= transform.position.x;
                        PosFut.y -= transform.position.y;
                        angulo = Mathf.Atan2(PosFut.y, PosFut.x) * Mathf.Rad2Deg;
                        rotationIF = float.Parse(rbEnemy.rotation.ToString("N4"));
                        anguloIF = float.Parse(angulo.ToString("N4"));
                        Rotação(angulo);
                        if(anguloIF == rotationIF || rotationIF == anguloIF * -1){
                        rodado = false;
                        AlreadyGet = false;
                        AlreadyAcesa = false;
                        GetComponent<scrPatrulha>().enabled = true;
                        GetComponent<ScrFOVMoeda>().enabled = true;
                        GetComponent<scrRotation>().enabled = true;
                        Tempo = Couldown;
                        lerp = 0;
                        Active = false;
                        }
                    }
                    else{
                        Tempo -= Time.deltaTime;
                    }
                }
                else{
                    if(GameObject.Find("Player").GetComponent<scrPlayer>().Acesa && targetsInRadius.Length > 0){
                        PosFut = GameObject.Find("Player").transform.position;
                        PosFut.z = 5f;
                        PosFut.x -= transform.position.x;
                        PosFut.y -= transform.position.y;
                    }
                    angulo = Mathf.Atan2(PosFut.y, PosFut.x) * Mathf.Rad2Deg;
                    rotationIF = float.Parse(rbEnemy.rotation.ToString("N4"));
                    anguloIF = float.Parse(angulo.ToString("N4"));
                    if(rotationIF == anguloIF){
                        rodado = true;
                        lerp = 0;
                    }

                    float z = rbEnemy.rotation;
                    lerp += Time.deltaTime / DuraçãoRot;
                    z = Mathf.LerpAngle(z, angulo, lerp);
                    rbEnemy.rotation = z;
                    AnimEnemy.SetBool("Andando", false);
                }
            }
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

    public void Rotação(float angulo){
        Quaternion rotacao = transform.rotation;
        z = rotacao.eulerAngles.z;
        lerp += Time.deltaTime / DuraçãoRot;
        z = Mathf.LerpAngle(z, angulo, lerp);
        rotacao = Quaternion.Euler(0, 0, z);
        transform.rotation = rotacao;
    }
}