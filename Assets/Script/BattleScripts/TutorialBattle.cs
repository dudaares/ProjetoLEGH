
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TutorialBattle : MonoBehaviour
{

    public List<GameObject> stepsTutorialList;
    public GameObject combatManager;
    public GameObject descriptionGroup;
    public GameObject actionGroup;
    public int stepInt;
    // Start is called before the first frame update
    void Start()
    {
        disableSteps(); 
        descriptionGroup.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (stepInt == 2)
        {
            descriptionGroup.SetActive(true);
        }
        else if (stepInt >= stepsTutorialList.Count)
        {
            descriptionGroup.SetActive(true);
          
        }
        else { descriptionGroup.SetActive(false); }

    }


    public void nextStep()
    {
        stepInt++;
        disableSteps();
        if (stepInt >= stepsTutorialList.Count)
        {
            descriptionGroup.transform.SetParent(actionGroup.transform, true);
            BattleManager.Instance.startCombatAfterTutorial();
        }
    }


    public void disableSteps()
    {

        for (int i = 0; i < stepsTutorialList.Count; i++)
        {
            if (i != stepInt)
            {
                stepsTutorialList[i].SetActive(false);
            }
            else { stepsTutorialList[stepInt].SetActive(true); }

        }

    }
}
