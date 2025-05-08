using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerInfos : MonoBehaviour
{
    public List<GameObject> doorPuzzleList;
    public List<GameObject> lightListComplete;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < doorPuzzleList.Count; i++)
        {
            if (PassInfos.Instance.puzzlesComplets[i] == true)
            {
                doorPuzzleList[i+1].SetActive(false);
             
            }
        }
        for (int i = 0;i < lightListComplete.Count; i++)
        {
            if (PassInfos.Instance.puzzlesComplets[i] == true)
            {
              
                lightListComplete[i].SetActive(true);
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
