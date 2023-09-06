using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Net.Component;
using Net.Client;
using Net.Share;
using TMPro;
using UnityEngine.UI;
using System;

public class UI_Chat : SingleCase<UI_Chat>
{
    public ChatItem leftItem, rightItem;
    private readonly List<ChatItem> items = new List<ChatItem>();
    public TMP_InputField inputMsg;
    public Button sendBtn,clanBtn,closeBtn;
    void Start()
    {
        sendBtn.onClick.AddListener(OnSendMsgClick);
        clanBtn.onClick.AddListener(OnClanClick);
        closeBtn.onClick.AddListener(OnCloseClick);

        leftItem.gameObject.SetActive(false);
        rightItem.gameObject.SetActive(false);
        ClientBase.Instance.AddRpc(this);
    }

    private void OnCloseClick()
    {
        Hide();
    }

    private void OnClanClick()
    {
        items.ClearObjects();
    }

    private void OnSendMsgClick()
    {
        var text = inputMsg.text;
        if (text.Length == 0)
        {
            Debug.Log("请输入聊天信息");
            return;
        }
        var info = new ChatInfo()
        {
            uid = Global.Data.Uid,
            nick = Global.Data.Nick,
            text = text
        };
        inputMsg.text = String.Empty;
        ClientBase.Instance.SendRT(NetCmd.SceneRT, (ushort)ProtoType.Chat, info);
    }

    private void OnDestroy()
    {
        ClientBase.Instance.RemoveRpc(this);
    }

    [Rpc(hash = (ushort)ProtoType.Chat)]
    private void Chat(ChatInfo chatInfo)
    {
        ChatItem item;
        if (chatInfo.uid == Global.Data.Uid)  //如果是自己就在左边
            item = Instantiate(leftItem, leftItem.transform.parent);
        else
            item = Instantiate(rightItem, rightItem.transform.parent);
        item.nick.text = chatInfo.nick;
        item.text.text = chatInfo.text;
        item.gameObject.SetActive(true);
        items.Add(item);
    }
}
