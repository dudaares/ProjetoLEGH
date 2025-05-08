using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityStats : MonoBehaviour
{
    public PlayerScriptable playerStats;
    public float baseSpeed;
    public float sanStm;
    // Start is called before the first frame update
    void Start()
    {
        baseSpeed = playerStats.baseSpeed;
        sanStm = playerStats.sanStm;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
