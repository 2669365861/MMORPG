using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool isLocalPlayer;
    public float moveSpeed = 12f;
    public Vector3 direction
    { 
        get { return new Vector3(Input.GetAxis("Horizontal"),0,Input.GetAxis("Vertical")); }
    }
    void Start()
    {
        
    }

    void Update()
    {
        if (!isLocalPlayer)
            return;
        var dir = Transform3Dir(Camera.main.transform, direction);
        if (dir != Vector3.zero)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(dir, Vector3.up), 0.5f);
            transform.Translate(0, 0, moveSpeed * Time.deltaTime);
        }
        else { 
        
        }
    }

    private Vector3 Transform3Dir(Transform t, Vector3 dir)
    {
        var f = Mathf.Deg2Rad * (-t.rotation.eulerAngles.y);
        dir.Normalize();
        var ret = new Vector3(dir.x * Mathf.Cos(f) - dir.z * Mathf.Sin(f), 0, dir.x * Mathf.Sin(f) + dir.z * Mathf.Cos(f));
        return ret;
     }
}
