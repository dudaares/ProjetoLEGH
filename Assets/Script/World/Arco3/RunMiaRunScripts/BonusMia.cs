using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusMia : MonoBehaviour
{
    public float bonusSpeed;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            RunMiaManager.Instance.baseMiaSpeed += bonusSpeed;
        }
    }


}
