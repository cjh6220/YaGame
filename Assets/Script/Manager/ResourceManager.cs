using System.Collections;
using System.Collections.Generic;
using UnityEngine;

static public class ResourceManager
{
    static public Sprite GetIcon(int type)
    {
        Sprite img = null;
        return img;
    }

    static public GameObject GetPopup(string str)
    {
        GameObject obj = null;
        obj = Resources.Load<GameObject>("Popup/" + str);
        return obj;
    }
}
