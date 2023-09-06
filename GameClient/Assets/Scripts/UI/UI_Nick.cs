using Cysharp.Threading.Tasks;
using Net.Client;
using Net.Component;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_Nick : SingleCase<UI_Nick>
{
    public TMP_InputField inputNick;
    public Button confirmBtn, closeBtn;
    void Start()
    {
        confirmBtn.onClick.AddListener(() => _ = OnConfirmClick());
    }

    private async UniTaskVoid OnConfirmClick()
    {
        var text = inputNick.text;
        if (text.Length == 0)
        {
            Debug.Log("请输入正确的昵称!");
            return;
        }
        var task = await ClientBase.Instance.Call((ushort)ProtoType.Nick, text);
        if (!task.IsCompleted)
        {
            Debug.LogError("请求超时!");
            return;
        }
        var code = task.model.AsInt;
        if (code == 0)
        {
            //进入主界面
            Debug.Log("马上进入主界面!");
            Global.Data.Nick = text;
            Hide();
            UI_Main.Show();
        }
        else {
            Debug.Log("未知错误!");
        }
    }
}
