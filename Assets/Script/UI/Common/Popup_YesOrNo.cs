using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Popup_YesOrNo : PopupBase
{
    [SerializeField] Button YesBtn;
    [SerializeField] Button NoBtn;
    [SerializeField] Text Title;
    [SerializeField] Text Expl;
    Action YesCallBack;
    Action NoCallBack;

    private void Awake()
    {
        YesBtn.onClick.AddListener(OnClickYes);
        NoBtn.onClick.AddListener(OnClickNo);
    }

    public void SetPopup(string title, string expl, Action yesCallback, Action noCallback)
    {
        Title.text = title;
        Expl.text = expl;
        YesCallBack = yesCallback;
        NoCallBack = noCallback;
    }

    void OnClickYes()
    {
        YesCallBack?.Invoke();
    }

    void OnClickNo()
    {
        NoCallBack?.Invoke();
    }
}
