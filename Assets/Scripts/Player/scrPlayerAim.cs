using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrPlayerAim : MonoBehaviour
{

    public Camera cam;

    public int posOffset;

    void FixedUpdate()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 5f;

        Vector3 objectPos = cam.WorldToScreenPoint(transform.position);

        mousePos.x = mousePos.x - objectPos.x;
        mousePos.y = mousePos.y - objectPos.y;

        float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle + posOffset));
    }
}
