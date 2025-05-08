using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartWarningPuzzle : MonoBehaviour
{
    public List<GameObject> gameObjects;

    public GameObject bispoAproxime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (DialogueManager.Instance.isPuzzle)
        {
            startWarning();
        }
    }

   public void startWarning()
    {
        for (int i = 0; i < gameObjects.Count; i++)
        {
            gameObjects[i].SetActive(true);
            bispoAproxime.SetActive(true);
          
        }
        gameObject.SetActive(false);
    }
}
