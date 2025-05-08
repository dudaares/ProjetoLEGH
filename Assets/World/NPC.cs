using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC : MonoBehaviour
{
    GameObject player;

    public DialogueScriptable dialogue;
    //alerta de aproximação
    public GameObject alertText;

    //Agrupamento das falas
    
   

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        CheackAproximation();
    }


    void CheackAproximation()
    {
        float dist = Vector2.Distance(transform.position, player.transform.position);

        if (dist > 3.5f)
        {
       
            alertText.SetActive(false);
           
        }
        else { alertText.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                // setar as infos do dialogo
               DialogueManager.Instance.dialogueReloadInfos(dialogue);
            }
        }
    }
}
