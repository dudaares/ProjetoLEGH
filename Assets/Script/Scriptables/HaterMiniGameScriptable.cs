using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "ComentariosMinigame", menuName = "ComentariosHaters" )]

public class HaterMiniGameScriptable : ScriptableObject
{
    public string nameObject;
    public string nickName;
    public string textComents;
    public Sprite imageAccount;
    public bool isHater;
}
