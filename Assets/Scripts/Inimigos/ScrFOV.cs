using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ScrFOV : MonoBehaviour
{

    public float TempoMoedaVista, rotationIF, anguloIF;

    float Tempo;

    Rigidbody2D rbEnemy;

    public Transform MoedaPos;

    Transform[] positions;

    int Local;

    Vector3 PosFut;

    public GameObject Moeda;

    public bool MoedaVista, Already, Rotacionando;

    public float viewRadius = 5;

    public float viewAngle = 115;

    public LayerMask obstacleMask, detectionMask;

    public Collider2D[] targetsInRadius;

    public List<Transform> visibleTargets = new List<Transform>();

    private void Update()
    {
        if(MoedaVista){
            MoedaFound();
        }else{
            FindVisibleTargets();
        }
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
                    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                }
            }
        }
    }

    public void MoedaFound(){
            GetComponent<scrRotation>().enabled = false;
            GetComponent<scrPatrulha>().enabled = false;
            Transform[] positions = GetComponent<scrPatrulha>().posições;
            int Local = GetComponent<scrPatrulha>().Local;
            Rigidbody2D rbEnemy = GetComponent<Rigidbody2D>();
            if(Moeda != null){
                MoedaPos = Moeda.transform;
                PosFut = MoedaPos.position;
            }
            else{
                MoedaPos = transform;
            }
        if(!Already){    
            PosFut.z = 5f;
            PosFut.x -= transform.position.x;
            PosFut.y -= transform.position.y;
            float angle = Mathf.Atan2(PosFut.y, PosFut.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle));
        }
        if(Vector2.Distance(transform.position, MoedaPos.position) < 0.5 || Moeda == null){
            Already = true;
            if(Vector2.Distance(transform.position, MoedaPos.position) > 0.5 || Moeda != null && !Rotacionando){
                Already = false;
            }
            if(Tempo <= 0){
                Rotacionando = true;
                Vector3 PosFutLocal = positions[Local].position;
                PosFutLocal.z = 5f;
                PosFutLocal.x -= transform.position.x;
                PosFutLocal.y -= transform.position.y;
                float angleLocal = Mathf.Atan2(PosFutLocal.y, PosFutLocal.x) * Mathf.Rad2Deg;
                GetComponent<scrRotation>().Rotação(angleLocal);
                rotationIF = float.Parse(rbEnemy.rotation.ToString("N2"));
                anguloIF = float.Parse(angleLocal.ToString("N2"));
                if(anguloIF == rotationIF){
                    if(Moeda != null){
                        Destroy(Moeda);
                    }
                    MoedaVista = false;
                    Already = false;
                    Rotacionando = false;
                    GetComponent<scrRotation>().enabled = true;
                    GetComponent<scrRotation>().lerp = 0f;
                    GetComponent<scrPatrulha>().enabled = true;
                }

            }
            else{
                Tempo -= Time.deltaTime;
            }
        }
        else{
            transform.position = Vector2.MoveTowards(transform.position, MoedaPos.position, 2 * Time.deltaTime);
            if(Vector2.Distance(transform.position, MoedaPos.position) < 1){
                Animator AnimEnemy;
                AnimEnemy = GetComponent<Animator>();
                AnimEnemy.SetBool("Andando", false);
            }else{
                Animator AnimEnemy;
                AnimEnemy = GetComponent<Animator>();
                AnimEnemy.SetBool("Andando", true);
                Tempo = TempoMoedaVista;
            }
        }
    }
}
