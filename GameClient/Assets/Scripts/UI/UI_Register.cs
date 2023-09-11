using Cysharp.Threading.Tasks;
using Net.Client;
using Net.Component;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_Register : SingleCase<UI_Register>
{
    public TMP_InputField account, password;
    public Button registerBtn, loginBtn, closeBtn;

    void Start()
    {
        registerBtn.onClick.AddListener(() => _ = OnRegisterClick());
    }

    private async UniTaskVoid OnRegisterClick()
    {
        var acc = account.text;
        var pwd = password.text;
        if (acc.Length == 0 | pwd.Length == 0)
        {
            UI_Message.Show("�������˺Ż�������!");
            return;
        }

        var task = await ClientBase.Instance.Call((ushort)ProtoType.Register, acc, pwd);
        if (!task.IsCompleted)
        {
            UI_Message.Show("����ʱ!");
            return;
        }
        var code = task.model.AsInt;
        if (code == -1)
        {
            UI_Message.Show("�˺��Ѵ���");
        }
        else {
            UI_Message.Show("ע��ɹ�!");
        }
    }
}
