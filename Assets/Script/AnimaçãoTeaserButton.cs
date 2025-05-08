using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class AnimaçãoTeaserButton : MonoBehaviour
{

    public PlayableDirector director;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void startScene()
    {
        director.Play();
        this.gameObject.SetActive(false);
    }
}
