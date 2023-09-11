using Cysharp.Threading.Tasks;
using Net.Client;
using Net.Component;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_Login : SingleCase<UI_Login>
{
    public TMP_InputField account,password;
    public Button loginBtn, registerBtn, closeBtn;

    void Start()
    {
        loginBtn.onClick.AddListener(() => _ = OnLoginClick());
        registerBtn.onClick.AddListener(OnRegisterClick); 
        closeBtn.onClick.AddListener(OnCloseClick);
    }

    private void OnCloseClick()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }

    private void OnRegisterClick()
    {
        UI_Register.Show();
    }

    private async UniTaskVoid OnLoginClick()
    {
        var acc = account.text;
        var pass = password.text;
        if (acc.Length == 0 | pass.Length == 0)
        {
            UI_Message.Show("请输入账号或者密码!");
            return;
        }
        var task = await ClientBase.Instance.Call((ushort)ProtoType.Login,acc,pass);
        if (!task.IsCompleted)
        {
            UI_Message.Show("登陆超时!");
            return;
        }
        var code = task.model.AsInt;
        var data = task.model.As<UserinfoData>();
        switch (code)
        {
            case -2:
                UI_Message.Show("账号不存在!");
                break;
            case -1:
                UI_Message.Show("密码错误!");
                break;
            case 0:
                Debug.Log("登录成功!");
                Global.Data = data;
                Hide();
                if (string.IsNullOrEmpty(data.Nick))//如果还没有昵称，则弹出 输入昵称界面
                {
                    UI_Nick.Show();
                }
                else {
                    Debug.Log("进入主界面");
                    UI_Main.Show();
                }
                break;
        }
    }
}
