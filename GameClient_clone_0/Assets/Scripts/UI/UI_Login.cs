using Cysharp.Threading.Tasks;
using Net.Client;
using Net.Component;
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
    }

    private async UniTaskVoid OnLoginClick()
    {
        var acc = account.text;
        var pass = password.text;
        if (acc.Length == 0 | pass.Length == 0)
        {
            Debug.LogError("请输入账号或者密码!");
            return;
        }
        var task = await ClientBase.Instance.Call((ushort)ProtoType.Login,acc,pass);
        if (!task.IsCompleted)
        {
            Debug.LogError("登陆超时!");
            return;
        }
        var code = task.model.AsInt;
        var data = task.model.As<UserinfoData>();
        switch (code)
        {
            case -2:
                Debug.Log("账号不存在!");
                break;
            case -1:
                Debug.Log("密码错误!");
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
