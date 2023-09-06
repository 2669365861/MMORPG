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
            Debug.Log("��������ȷ���ǳ�!");
            return;
        }
        var task = await ClientBase.Instance.Call((ushort)ProtoType.Nick, text);
        if (!task.IsCompleted)
        {
            Debug.LogError("����ʱ!");
            return;
        }
        var code = task.model.AsInt;
        if (code == 0)
        {
            //����������
            Debug.Log("���Ͻ���������!");
            Global.Data.Nick = text;
            Hide();
            UI_Main.Show();
        }
        else {
            Debug.Log("δ֪����!");
        }
    }
}
