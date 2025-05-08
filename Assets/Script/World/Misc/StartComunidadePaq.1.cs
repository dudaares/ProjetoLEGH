using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartComunidadePaq : MonoBehaviour
{
    public DialogueScriptable dialogue;
    // Start is called before the first frame update
    void Start()
    {
        DialogueManager.Instance.dialogueReloadInfos(dialogue);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
