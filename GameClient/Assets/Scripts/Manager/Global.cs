using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Net.Component;

public class Global : SingleCase<Global>
{
    internal static UserinfoData Data;//����½�ɹ������������������������ݶ��� 

    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(gameObject);
    }
}
