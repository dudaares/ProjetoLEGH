using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventDialogueStart : MonoBehaviour
{


    
    
    // Start is called before the first frame update
    void Start()
    {
        if (PassInfos.Instance.startDialogue == true)
        {
            DialogueManager.Instance.dialogueReloadInfos(PassInfos.Instance.DialogueScriptable);            PassInfos.Instance.startDialogue = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
