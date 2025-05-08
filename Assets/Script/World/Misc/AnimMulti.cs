using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimMulti : MonoBehaviour
{

    public AnimationClip animation;
    public List<GameObject> objects;
    bool canRun;
    // Start is called before the first frame update
    void Start()
    {
        objects = new List<GameObject>(GameObject.FindGameObjectsWithTag("PeaoVermelho"));
        canRun = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (canRun)
        {
            for (int i = 0; i < objects.Count; i++)
            {
                objects[i].GetComponent<Animator>().Play("PeaoVermelho_Anim_Mov_Baixo");
            }
        }
    }


    public void animaitonEvery()
    {
        canRun = true;
    }
}
