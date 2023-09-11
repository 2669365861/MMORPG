using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameDesigner;
using BuildComponent;

public class Player : MonoBehaviour
{
    public bool isLocalPlayer;
    public float moveSpeed = 12f;
    public StateManager sm;
    public NetworkAnimator anim;
    public Vector3 direction
    { 
        get { return new Vector3(Input.GetAxis("Horizontal"),0,Input.GetAxis("Vertical")); }
    }
    void Start()
    {

    }

    //void Update()
    //{
    //    if (!isLocalPlayer)
    //        return;
    //    var dir = Transform3Dir(Camera.main.transform, direction);
    //    if (dir != Vector3.zero)
    //    {
    //        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(dir, Vector3.up), 0.5f);
    //        transform.Translate(0, 0, moveSpeed * Time.deltaTime);
    //    }
    //    else { 
        
    //    }
    //}

    public Vector3 Transform3Dir(Transform t, Vector3 dir)
    {
        var f = Mathf.Deg2Rad * (-t.rotation.eulerAngles.y);
        dir.Normalize();
        var ret = new Vector3(dir.x * Mathf.Cos(f) - dir.z * Mathf.Sin(f), 0, dir.x * Mathf.Sin(f) + dir.z * Mathf.Cos(f));
        return ret;
     }
}

/// <summary>
/// ��Ϣ״̬��վ��״̬
/// </summary>
public class IdleState : StateBehaviour
{
    private Player self;

    public override void OnInit()//����ʼ��������Start
    {
        self = transform.GetComponent<Player>();
    }

    public override void OnEnter()//����Ϣ״̬����
    {
        self.anim.Play(state.name);
    }

    public override void OnUpdate()//����Ϣ״̬ÿһ֡
    {
        if (!self.isLocalPlayer)
            return;
        if (Input.GetKeyDown(KeyCode.Q))
        {
            EnterState(2);//���빥��״̬
            return;
        }
        var dir = self.Transform3Dir(Camera.main.transform, self.direction);
        if (dir != Vector3.zero)
        {
            EnterState(1);//���뱼��״̬
        }
    }
}

/// <summary>
/// ����״̬
/// </summary>
public class RunState : StateBehaviour
{
    private Player self;

    public override void OnInit()
    {
        self = transform.GetComponent<Player>();
    }

    public override void OnEnter()
    {
        self.anim.Play(state.name);
    }

    public override void OnUpdate()
    {
        if (!self.isLocalPlayer)
            return;
        if (Input.GetKeyDown(KeyCode.Q))
        {
            EnterState(2);//���빥��״̬
            return;
        }
        var dir = self.Transform3Dir(Camera.main.transform, self.direction);
        if (dir != Vector3.zero)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(dir, Vector3.up), 0.5f);
            transform.Translate(0, 0, self.moveSpeed * Time.deltaTime);
        }
        else {
            EnterState(0);//����վ��״̬
        }
    }
}

/// <summary>
/// ����״̬
/// </summary>
public class AttackState : StateBehaviour
{
    private Player self;

    public override void OnInit()
    {
        self = transform.GetComponent<Player>();
    }

    public override void OnEnter()
    {
        self.anim.Play(state.name);
    }
}

/// <summary>
/// ����״̬
/// </summary>
public class DieState : StateBehaviour
{
    private Player self;

    public override void OnInit()
    {
        self = transform.GetComponent<Player>();
    }

    public override void OnEnter()
    {
        self.anim.Play(state.name);
    }
}