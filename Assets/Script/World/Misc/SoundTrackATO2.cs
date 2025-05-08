using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SoundTrackATO2 : MonoBehaviour
{

    public AudioSource redSide;
    public AudioSource blueSide;

    public float maxVolume;

    public bool startCoroutine;
    public bool isCoroutineRun;
    public bool startTradeSong;

    
    public bool redSideActive;

    GameObject player;
    public float duration;
    float time;
    float startVolume;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        blueSide.volume = 0;
        redSide.volume = maxVolume;
        redSideActive = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        tradeSound();
        if (redSideActive)
        {
            redSide.volume = maxVolume;
        }
        else
        {
            blueSide.volume = maxVolume;
        }
    }

    public void tradeSound()
    {
        if (player.transform.position.x < transform.position.x && startTradeSong)
        { 
           if (!isCoroutineRun && startCoroutine)
            {
              StartCoroutine(startRedSideMusic());
            }
        }
        else if (player.transform.position.x > transform.position.x && startTradeSong)
        {

            if (!isCoroutineRun && startCoroutine)
            {
                StartCoroutine(startBlueSideMusic());
            }
        }
        }


    IEnumerator startRedSideMusic()
    {
        isCoroutineRun = true;
        startCoroutine = false;
        startVolume = blueSide.volume;
        while (time < duration)
        {
            time += Time.deltaTime;
            redSide.volume = Mathf.Lerp(0f, maxVolume, time / duration);
            blueSide.volume = Mathf.Lerp(startVolume, 0f,time/duration);
            yield return null;
        }
        
       time = 0f;
        redSide.volume = maxVolume;
        blueSide.volume = 0;
        redSideActive = true;
        startTradeSong = false;
        yield break;
    }
    IEnumerator startBlueSideMusic()
    {
        isCoroutineRun = true;
        startCoroutine = false;
        startVolume = redSide.volume;
        while (time < duration)
        {
            time += Time.deltaTime;
            blueSide.volume = Mathf.Lerp(0f, maxVolume, time / duration);
            redSide.volume = Mathf.Lerp(startVolume, 0f, time / duration);
            yield return null;
        }
   time = 0f;
        redSide.volume = 0;
        blueSide.volume = maxVolume;
        startTradeSong = false;
        redSideActive = false;
        yield break;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            
            
            startTradeSong = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {

            isCoroutineRun = false;
            startCoroutine = true;
           
        }
    }

}


