using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LocalizeManager : MonoBehaviour
{
    public static LocalizeManager instance;
    public LocalizeType Language = LocalizeType.kr;
    Dictionary<string, string> dic = new Dictionary<string, string>();
    private void Awake()
    {
        if (instance != null) //이미 존재하면
        {
            Destroy(gameObject); //두개 이상이니 삭제
            return;
        }
        instance = this; //자신을 인스턴스로
        DontDestroyOnLoad(gameObject); //씬 이동해도 사라지지않게
        LoadCSV();
    }

    void LoadCSV()
    {
        dic.Clear();
        var target = CSVReader.ReadOriginal("DialogueText");
        for (int i = 0; i < target.Count; i++)
        {
            string key = target[i]["Id"].ToString();
            string value = "";
            switch (Language)
            {
                case LocalizeType.kr:
                    {
                        value = target[i]["kr"].ToString();
                    }
                    break;
                case LocalizeType.jp:
                    {
                        value = target[i]["jp"].ToString();
                    }
                    break;
                case LocalizeType.en:
                    {
                        value = target[i]["en"].ToString();
                    }
                    break;
                case LocalizeType.tw:
                    {
                        value = target[i]["tw"].ToString();
                    }
                    break;
            }
            dic.Add(key, value);
        }
    }

    public string GetLocalize(string key)
    {
        return dic[key];
    }
}

public enum LocalizeType
{
    None,
    kr,
    jp,
    en,
    tw
}
