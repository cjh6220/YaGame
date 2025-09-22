using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Popup_NewGame : PopupBase
{
    [SerializeField] Button CloseBtn;
    [SerializeField] Popup_NewGame_Item[] Items;

    private void Awake()
    {
        CloseBtn.onClick.AddListener(() => Popup_Manager.instance.ClosePopup(this));
    }

    private void Start()
    {
        SetItem();
    }

    void SetItem()
    {
        for (int i = 0; i < Items.Length; i++)
        {
            if (i == 0)
            {
                Items[i].SetItem(i, true, OnClickItem);
            }
            else
            {
                Items[i].SetItem(i, false, OnClickItem);
            }
        }
    }

    void OnClickItem(int idx)
    {
        SceneManager.LoadScene("GameScene");
        Popup_Manager.instance.ClosePopup(this);
    }
}
