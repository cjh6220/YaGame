using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager instance;
    Dictionary<int, DialogueData> dic = new Dictionary<int, DialogueData>();
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
        var target = CSVReader.ReadOriginal("DialogueSet");
        for (int i = 0; i < target.Count; i++)
        {
            var _data = new DialogueData();
            _data.Index = int.Parse(target[i]["Index"].ToString());
            _data.Group = int.Parse(target[i]["Id_Group"].ToString());
            _data.Id = int.Parse(target[i]["Id"].ToString());
            _data.Event_Type = (Dialogue_EventType)Enum.Parse(typeof(Dialogue_EventType), target[i]["Event_Type"].ToString());

            if (!string.IsNullOrEmpty(target[i]["Char_Slot"].ToString()))
            {
                var slot = target[i]["Char_Slot"].ToString().Split('/');
                _data.Char_Slot = new int[slot.Length];
                for (int a = 0; a < slot.Length; a++)
                {
                    _data.Char_Slot[a] = int.Parse(slot[a]);
                }
            }

            if (!string.IsNullOrEmpty(target[i]["Char_Img"].ToString()))
            {
                var img = target[i]["Char_Img"].ToString().Split('/');
                _data.Char_Img = new string[img.Length];
                for (int a = 0; a < img.Length; a++)
                {
                    _data.Char_Img[a] = img[a];
                }
            }

            if (!string.IsNullOrEmpty(target[i]["Char_Direction"].ToString()))
            {
                var dir = target[i]["Char_Direction"].ToString().Split('/');
                _data.Char_Direction = new Dialogue_Char_Direction[dir.Length];
                for (int a = 0; a < dir.Length; a++)
                {
                    _data.Char_Direction[a] = (Dialogue_Char_Direction)Enum.Parse(typeof(Dialogue_Char_Direction), dir[a]);
                }
            }

            if (!string.IsNullOrEmpty(target[i]["Char_Offset"].ToString()))
            {
                var offset = target[i]["Char_Offset"].ToString().Split('/');
                _data.Char_Offset = new Vector3[offset.Length];
                for (int a = 0; a < offset.Length; a++)
                {
                    var vec = offset[a].Split(',');
                    _data.Char_Offset[a] = new Vector3(float.Parse(vec[0]), float.Parse(vec[1]), float.Parse(vec[2]));
                }
            }

            _data.Ani_Trigger = target[i]["Ani_Trigger"].ToString();
            _data.Text_Name = target[i]["Text_Name"].ToString();
            _data.Text_Script = target[i]["Text_Script"].ToString();

            if (!string.IsNullOrEmpty(target[i]["Cam_Shake_Time"].ToString()))
            {
                _data.Cam_Shake_Time = float.Parse(target[i]["Cam_Shake_Time"].ToString());
            }
            
            if (!string.IsNullOrEmpty(target[i]["Cam_Shake_Pow"].ToString()))
            {
                _data.Cam_Shake_Pow = float.Parse(target[i]["Cam_Shake_Pow"].ToString());
            }
            
            if (!string.IsNullOrEmpty(target[i]["Delay"].ToString()))
            {
                _data.Delay = float.Parse(target[i]["Delay"].ToString());
            }
            _data.Auto = target[i]["Auto"].ToString() == "TRUE";
            _data.Voice = target[i]["Voice"].ToString();
            _data.Sfx = target[i]["Sfx"].ToString();
            _data.Bgm = target[i]["Bgm"].ToString();

            dic.Add(_data.Index, _data);
        }
    }
}

public class DialogueData
{
    public int Index;
    public int Group;
    public int Id;
    public Dialogue_EventType Event_Type;
    public int[] Char_Slot = new int[0];
    public string[] Char_Img = new string[0];
    public Dialogue_Char_Direction[] Char_Direction = new Dialogue_Char_Direction[0];
    public Vector3[] Char_Offset = new Vector3[0];
    public string Ani_Trigger;
    public string Text_Name;
    public string Text_Script;
    public float Cam_Shake_Time = 0f;
    public float Cam_Shake_Pow= 0f;
    public float Delay = 0f;
    public bool Auto;
    public string Voice;
    public string Sfx;
    public string Bgm;
    public float Fade_Time;
    //public Color Fade_Color;
}

public enum Dialogue_EventType
{
    None,
    Event,
    Dialogue,
    Choice
}

public enum Dialogue_Char_Direction
{
    None,
    Right,
    Left
}
