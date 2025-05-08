using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TradeAnimation : MonoBehaviour
{
    [SerializeField] private Animator animator;
    public string animationName;
    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();

        animator.Play(animationName);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TradeAnimatioon()
    {

        animator.Play(animationName);
    }
}
