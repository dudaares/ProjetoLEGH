using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AttackStats", menuName = "Actions")]
public class AttackScriptable : ScriptableObject
{

    public string nameTitle;
    public string useCombat;
    public string combatDescr;
    public List<string> fraseAction;
    public float dmg;
    public float costStm;
    public bool learned;
    [Space(2)]
    public AudioClip audioClip;
    
    [Header("Type action....")]
    public string typeAction;
    public bool buffPlayer;
    public float modificadorBuffOrDebuff;
    //player
    public int turnsForTimingAction;

    //enemy
    [Header("Enemy type action....")]
    public int turnsForTimingActionEnemy;
}
