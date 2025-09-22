using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameDialogue : MonoBehaviour
{
    [SerializeField] Text Name;
    [SerializeField] Text Expl;

    [Header("Parent")]
    [SerializeField] GameObject DefaultUI;
    [SerializeField] GameObject HideUI;

    [Header("Buttons")]
    [SerializeField] Button HideBtn;
    [SerializeField] Button Auto;
    [SerializeField] Button Skip;
    [SerializeField] Button Setting;
    [SerializeField] Button ShowBtn;
    [SerializeField] Button NextBtn;

    bool _isHide = false;

    private void Awake()
    {
        HideBtn.onClick.AddListener(OnClickHide);
        ShowBtn.onClick.AddListener(OnClickHide);
        Auto.onClick.AddListener(OnClickAuto);
        Skip.onClick.AddListener(OnClickSkip);
        Setting.onClick.AddListener(OnClickSetting);
        NextBtn.onClick.AddListener(OnClickNext);
    }

    public void SetDialogue()
    {
        
    }

    #region  ButtonAction
    void OnClickHide()
    {
        _isHide = !_isHide;

        DefaultUI.SetActive(!_isHide);
        HideUI.SetActive(_isHide);
    }

    void OnClickAuto()
    {

    }

    void OnClickSkip()
    {

    }

    void OnClickSetting()
    {

    }

    void OnClickNext()
    {

    }
    #endregion
}
