using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Net.Component;
using UnityEngine.UI;
using System;
using Cysharp.Threading.Tasks;
using UnityEngine.SceneManagement;

public class UI_Main : SingleCase<UI_Main>
{
    public Button chatBtn;
    void Start()
    {
        chatBtn.onClick.AddListener(OnChatClick);

        SceneManager.LoadScene("Game");
    }

    private void OnChatClick()
    {
        UI_Chat.Show();
    }
}
