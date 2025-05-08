using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisabelTradeAction : MonoBehaviour
{
    public bool disable_;
    // Start is called before the first frame update
    void Start()
    {
        TraderAction.Instance.gameObject.SetActive(disable_);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
