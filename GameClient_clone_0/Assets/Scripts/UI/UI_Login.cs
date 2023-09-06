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
            Debug.LogError("�������˺Ż�������!");
            return;
        }
        var task = await ClientBase.Instance.Call((ushort)ProtoType.Login,acc,pass);
        if (!task.IsCompleted)
        {
            Debug.LogError("��½��ʱ!");
            return;
        }
        var code = task.model.AsInt;
        var data = task.model.As<UserinfoData>();
        switch (code)
        {
            case -2:
                Debug.Log("�˺Ų�����!");
                break;
            case -1:
                Debug.Log("�������!");
                break;
            case 0:
                Debug.Log("��¼�ɹ�!");
                Global.Data = data;
                Hide();
                if (string.IsNullOrEmpty(data.Nick))//�����û���ǳƣ��򵯳� �����ǳƽ���
                {
                    UI_Nick.Show();
                }
                else {
                    Debug.Log("����������");
                    UI_Main.Show();
                }
                break;
        }
    }
}
