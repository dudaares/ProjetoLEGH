using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "puzzleDialogueScriptable", menuName = "PuzzleDialogue")]
public class PuzzleDialogueScriptable : ScriptableObject
{
    public string question;
    public List<string> answers;
    public List<DialogueScriptable> answerIncorretDialogue;
    public int correctAnswers;
}
