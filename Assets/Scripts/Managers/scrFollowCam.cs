using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrFollowCam : MonoBehaviour
{
    public GameObject PTFollow;
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, PTFollow.transform.position, 10);
    }
}
