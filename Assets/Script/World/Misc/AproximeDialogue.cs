using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AproximeDialogue : MonoBehaviour
{


    
    public GameObject storeButtonWarining;
    public GameObject storeWarning;
    public List<DialogueScriptable> dialogue;
  
    GameObject playerObject;

    public bool revDialogue;
    public bool bispoDialogue;
   
    public bool oneDialogue;
    public int numberDialogue;
    bool block = false;

    // Start is called before the first frame update
    void Start()
    {
        playerObject = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
        blockDialogue();
        if (revDialogue)
        {
            numberDialogue = DialogueManager.Instance.numberDialogueNpc;
        }
    }

    public void blockDialogue()
    {
        if (oneDialogue == true)
        {
            float dist = Vector2.Distance(transform.position, playerObject.transform.position);


            if (block == false)
            {
                if (dist < 2.5f)
                {

                    if (!DialogueManager.Instance.isDialogue || DialogueManager.Instance.isPuzzle)
                    { storeButtonWarining.SetActive(true); }

                    storeButtonWarining.SetActive(true);

                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        storeWarning.SetActive(false);
                        storeButtonWarining.SetActive(false);
                        block = true;
                        storeButtonWarining.SetActive(false);
                        DialogueManager.Instance.dialogueReloadInfos(dialogue[numberDialogue]);

                    }
                }
                else
                {

                    storeButtonWarining.SetActive(false);

                }
            }
        }
        else {
            float dist = Vector2.Distance(transform.position, playerObject.transform.position);
            if (dist < 2.5f)
            {
                if (!DialogueManager.Instance.isDialogue || DialogueManager.Instance.isPuzzle )
                { storeButtonWarining.SetActive(true); }
               

                if (Input.GetKeyDown(KeyCode.E))
                {
                    storeWarning.SetActive(false);
                    
                    storeButtonWarining.SetActive(false);

                    DialogueManager.Instance.dialogueReloadInfos(dialogue[numberDialogue]);
                    if (bispoDialogue && DialogueManager.Instance.isRevulocaoDialogue)
                    {
                        DialogueManager.Instance.isBispoDialogue = true;
                        bispoDialogue = false;
                        storeWarning.SetActive(true);
                    }
                    else if (revDialogue) { DialogueManager.Instance.isRevulocaoDialogue = true; }
                    else { }


                }
            }
            else
            {

                storeButtonWarining.SetActive(false);
                

            }
        }
    }
}
