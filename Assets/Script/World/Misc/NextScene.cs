using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{

    [SerializeField] bool isStart;
    [SerializeField] string sceneName;
    public EnemysScriptable enemy;
    // Start is called before the first frame update
    void Start()
    {
        if (isStart)
        {
            TransitionSceneManager.Instance.Transition(sceneName);
            PassInfos.Instance.enemyToPass = enemy;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadScene(string scene)
    {
        TransitionSceneManager.Instance.Transition(scene);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            TransitionSceneManager.Instance.Transition(sceneName);
        }
    }
}
