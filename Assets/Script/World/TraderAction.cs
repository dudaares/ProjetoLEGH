using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TraderAction : MonoBehaviour
{
    public static TraderAction Instance { get; private set; }

    public List<AttackScriptable> actionList;

    GameObject player;

    public int maxAction = 4;
    public int numberAction;
    public Button openShopButton;
    public GameObject shopItem;
    public GameObject shopBG;
    public GameObject shopGroup;
  
  
    public List<GameObject> gameObjectsList;

    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {

        player = GameObject.FindGameObjectWithTag("Player");
        maxAction = 4;
        openShopButton.onClick.AddListener(actionForSelect);

    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Battle" || SceneManager.GetActiveScene().name == "BattleTutorial" || SceneManager.GetActiveScene().name == "ComunidadePAQ" || SceneManager.GetActiveScene().name == "ComunidadePAQ.1" || SceneManager.GetActiveScene().name == "StartWorldProto" || SceneManager.GetActiveScene().name == "RunMiaRun")
        {
            openShopButton.gameObject.SetActive(false);
        }
        else
        {
            openShopButton.gameObject.SetActive(true);
        }
    }

    public void actionForSelect()
    {
        openShopButton.gameObject.SetActive(false);
        shopGroup.SetActive(true);
        for (int i = 0; i < actionList.Count; i++)
        {
            GameObject newObjectIconAction = Instantiate(shopItem, shopBG.transform);
            newObjectIconAction.GetComponent<ActionInconScript>().action = actionList[i];   
            newObjectIconAction.GetComponent<ActionInconScript>().setuUp(actionList[i]);
        
        }
    }

    public void closeSlection()
    {
        if (PassInfos.Instance.actionPlayer.Count == 4)
        {
            shopGroup.SetActive(false);
            openShopButton.gameObject.SetActive(true);
            for (int i = 0; i < gameObjectsList.Count; i++)
            {
                Destroy(gameObjectsList[i]);
            }

        }
    }

    IEnumerator fade()
    {
      
            // loop over 1 second
            for (float i = 0; i <= 1; i += Time.deltaTime)
            {
                // set color with i as alpha
                openShopButton.GetComponent<Image>().color = new Color(1, 1, 1, i);
                yield return null;
            }
        
    }
}
