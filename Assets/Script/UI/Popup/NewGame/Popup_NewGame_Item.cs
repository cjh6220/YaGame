using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Popup_NewGame_Item : MonoBehaviour
{
    [SerializeField] Button Btn;
    [SerializeField] GameObject Dim;
    [SerializeField] Text Title;

    int _idx;
    Action<int> _callback;

    private void Awake()
    {
        Btn.onClick.AddListener(OnClickBtn);
    }

    public void SetItem(int idx, bool isActive, Action<int> callback)
    {
        _idx = idx;
        Dim.SetActive(!isActive);
        Title.text = $"에피소드 {idx + 1}";
        _callback = callback;
    }

    void OnClickBtn()
    {
        _callback?.Invoke(_idx);
    }
}
