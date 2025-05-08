using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartDialoguePassInfos : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        DialogueManager.Instance.dialogueReloadInfos(PassInfos.Instance.DialogueScriptable); 
    }

}
