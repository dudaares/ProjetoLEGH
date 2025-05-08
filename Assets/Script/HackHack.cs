using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HackHack : MonoBehaviour
{
    public DialogueScriptable dialogue;
    public EnemysScriptable enemys;
    public GameObject inputFlied;
    public AttackScriptable attack;
    public string scene;
    bool eita;
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightShift) )
        {
            nextScene(scene);
        }
       
    }
        public void nextScene(string scene)
        {
            SceneManager.LoadScene(scene);
        }
}

