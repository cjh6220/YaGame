using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LobbyManager : MonoBehaviour
{
    [Header("Button")]
    [SerializeField] Button NewGame_Btn;
    [SerializeField] Button LoadGame_Btn;
    [SerializeField] Button Gallery_Btn;
    [SerializeField] Button Exit_Btn;

    private void Awake()
    {
        NewGame_Btn.onClick.AddListener(OnClickNewGame);
        LoadGame_Btn.onClick.AddListener(OnClickLoadGame);
        Gallery_Btn.onClick.AddListener(OnClickGallery);
        Exit_Btn.onClick.AddListener(OnClickExit);
    }

    void OnClickNewGame()
    {
        Popup_Manager.instance.OpenPopup("Popup_NewGame");
    }

    void OnClickLoadGame()
    {

    }

    void OnClickGallery()
    {

    }

    void OnClickExit()
    {
        var popup = Popup_Manager.instance.OpenPopup("Popup_YesOrNo");
        if (popup != null)
        {
            var target = popup.GetComponent<Popup_YesOrNo>();
            target.SetPopup("게임종료", "게임을 종료하시겠습니까?", () => Application.Quit(), () => Popup_Manager.instance.ClosePopup(target));
        }
    }
}
