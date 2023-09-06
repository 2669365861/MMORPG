using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Net.Component;

public class Global : SingleCase<Global>
{
    internal static UserinfoData Data;//当登陆成功后服务器发送下来的玩家数据对象 

    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(gameObject);
    }
}
