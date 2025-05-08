using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventDialogue1 : MonoBehaviour
{

    public DialogueScriptable dialogue;
    
    public GameObject gameobject;
    public bool isPuzzle;
  
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (isPuzzle)
            {
                PuzzleDialogue.Instance.dialoguePuzzleReloadInfos(dialogue);
            }
            else
            {
                DialogueManager.Instance.dialogueReloadInfos(dialogue);
            }
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            if (gameobject !=null)
            { DialogueManager.Instance.gameobject = gameobject; }
            
}
    }
}
