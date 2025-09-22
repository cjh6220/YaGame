using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameManager : MonoBehaviour
{
    public static InGameManager instance;
    public InGameDialogue DialogueManager;
    private void Awake()
    {
        if (instance != null) //이미 존재하면
        {
            Destroy(gameObject); //두개 이상이니 삭제
            return;
        }
        instance = this; //자신을 인스턴스로
    }


}
