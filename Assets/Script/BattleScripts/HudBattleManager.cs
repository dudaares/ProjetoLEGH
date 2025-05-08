using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HudBattleManager : MonoBehaviour
{

    public static HudBattleManager Instance { get; private set; }

  
    
    public GameObject actionStep;
    public GameObject textStep;
    public Image imageEnemy;
    public GameObject loseScreen;

    public Slider battleBar;

    public TextMeshProUGUI textBalonPlayer;
    public TextMeshProUGUI textBalonEnemy;
    public GameObject balonPlayer;
    public GameObject balonEnemy;

    public Slider energyBar;

    public Text textGeral;
    public Text textPequeno;
    public Text textStm;
    public TextMeshProUGUI actionDescripiton;
    public TextMeshProUGUI energyDescription;
    

    public List<GameObject> buttons;
    public List<Text> valueStm;
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
        startTextStep();
     
        textGeral.text = "Bora para a luta??";
        NameForButtons();
        balonPlayer.SetActive(false);
        balonEnemy.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        battleBar.value = BattleManager.Instance.valueBar;
        textStm.text = BattleManager.Instance.stamina.ToString() + "/" + BattleManager.Instance.staminaMax.ToString();
        energyBar.value = BattleManager.Instance.stamina;
    }

    

    public void NameForButtons()
    {
        for (int i = 0; i < buttons.Count; i++)
        {
            buttons[i].GetComponentInChildren<Text>().text = BattleManager.Instance.attacksPlayer[i].nameTitle;

            int currentIdex = i;

            // Configurar o EventTrigger
            EventTrigger trigger = buttons[i].GetComponent<EventTrigger>();
            if (trigger == null)
                trigger = buttons[i].AddComponent<EventTrigger>();

            // Limpar entradas anteriores
            trigger.triggers.Clear();

            // Criar entrada para PointerEnter (quando o mouse passa por cima)
            EventTrigger.Entry entryEnter = new EventTrigger.Entry();
            entryEnter.eventID = EventTriggerType.PointerEnter;
            entryEnter.callback.AddListener((data) => { descriptionAction(currentIdex); });
            trigger.triggers.Add(entryEnter);

            // Opcional: limpar descrição ao sair
            EventTrigger.Entry entryExit = new EventTrigger.Entry();
            entryExit.eventID = EventTriggerType.PointerExit;
            entryExit.callback.AddListener((data) => {
                if (actionDescripiton != null)
                    actionDescripiton.text = "";
            });

            if (BattleManager.Instance.stamina < -(BattleManager.Instance.attacksPlayer[i].costStm))
            {
                //mudar a aparancia do botao quando voce n tem estamina para usar a ação
                buttons[i].GetComponent<Image>().color = Color.grey; 
            }
            else
            {
                buttons[i].GetComponent<Image>().color = Color.white;
            }
        }
    }

    public void descriptionAction(int i)
    {
        // Verifique se o índice está dentro dos limites da lista
        if (i >= 0 && i < BattleManager.Instance.attacksPlayer.Count)
        {
            // Acesse o ataque pelo índice e mostre a descrição
                Debug.Log("Deu certo patrão" + BattleManager.Instance.attacksPlayer[i]);
                actionDescripiton.text = BattleManager.Instance.attacksPlayer[i].combatDescr; // Ou qualquer propriedade que você queira mostrar
            if (BattleManager.Instance.attacksPlayer[i].costStm < 0)
            {
                energyDescription.text = BattleManager.Instance.attacksPlayer[i].costStm.ToString() + " Energia";

            }
            else
            {
                energyDescription.text = "+" + BattleManager.Instance.attacksPlayer[i].costStm.ToString() + " Energia";

            }
        }
        else
        {
            // Índice inválido, limpe a descrição ou mostre uma mensagem padrão
            if (actionDescripiton != null)
                Debug.Log("errado patrinho");
            actionDescripiton.text = "";
        }
    }
   
    public IEnumerator animationAttack(AttackScriptable attack, bool isPlayer)
    {
        if (isPlayer)
        {
            balonPlayer.SetActive(true);
            textBalonPlayer.text = attack.fraseAction[Random.Range(attack.fraseAction.Count - 1, 0)];
            textGeral.text = attack.useCombat;

            yield return new WaitForSeconds(1);
            balonPlayer.SetActive(false);
            yield break;
        }
       else if (!isPlayer)
        {
            balonEnemy.gameObject.SetActive(true);
            textBalonEnemy.text = attack.fraseAction[Random.Range(attack.fraseAction.Count - 1, 0)];
            textGeral.text = attack.useCombat;

            yield return new WaitForSeconds(1);
            balonEnemy.gameObject.SetActive(false);
            yield break;
        }


    }

    public void startActionStep()
    {
        actionStep.SetActive(true);
        textStep.SetActive(false);
        NameForButtons();

    }

    public void startTextStep()
    {
        textStep.SetActive(true);
        actionStep.SetActive(false);

    }
}
