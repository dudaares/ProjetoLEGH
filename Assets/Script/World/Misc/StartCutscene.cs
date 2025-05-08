using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class ColliderCutscene : MonoBehaviour
{
    PlayableDirector director;
    public PlayableAsset cutScene;

    // Start is called before the first frame update
    void Start()
    {
        director = GameObject.FindGameObjectWithTag("DirectorCutscene").GetComponent<PlayableDirector>();    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            director.playableAsset = cutScene;
            director.Play();
            gameObject.GetComponent<BoxCollider2D>().enabled = false;

        }
    }
}
