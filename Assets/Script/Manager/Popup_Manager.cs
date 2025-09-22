using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Popup_Manager : MonoBehaviour
{
    public static Popup_Manager instance;
    List<PopupBase> PopupList = new List<PopupBase>();
    List<PopupBase> OpenPopupList = new List<PopupBase>();
    void Awake()
    {
        if (instance != null) //이미 존재하면
        {
            Destroy(gameObject); //두개 이상이니 삭제
            return;
        }
        instance = this; //자신을 인스턴스로
        DontDestroyOnLoad(gameObject); //씬 이동해도 사라지지않게
    }

    public GameObject OpenPopup(string str)
    {
        var temp = PopupList.Find(t => t.name == str);
        if (temp != null)
        {
            temp.Open();
            temp.gameObject.SetActive(true);
            OpenPopupList.Add(temp);
            return temp.gameObject;
        }

        var obj = ResourceManager.GetPopup(str);
        if (obj != null)
        {
            var target = Instantiate(obj, transform);
            target.name = str;
            var popup = target.GetComponent<PopupBase>();
            if (popup != null)
            {
                PopupList.Add(popup);
                OpenPopupList.Add(popup);
                popup.Open();
            }
            return target;
        }
        return null;
    }

    public void ClosePopup(PopupBase pb)
    {
        var target = OpenPopupList.Find(t => t == pb);
        if (target != null)
        {
            pb.Close();
            target.gameObject.SetActive(false);
            OpenPopupList.Remove(target);
        }
    }

    public void ClosePopup()
    {
        var target = OpenPopupList.Last();
        target.Close();
        target.gameObject.SetActive(false);
        OpenPopupList.Remove(target);
    }
}
