using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Volume : MonoBehaviour
{


    public static Volume Instance { get; private set; }

    public AudioSource soundTrackVolume;
    public Slider volumeSlider;
    public GameObject volumeSliderObj;
    public GameObject button;
    public GameObject soundTrackObject;
    bool volumeSliderOpen;


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

    void Start()
    {
     takeSoundTrack();
        volumeSliderObj.SetActive(false);
        volumeSliderOpen = false; 
    }

    // Update is called once per frame
    void Update()
    {
        if (soundTrackVolume != null)
        {
            soundTrackVolume.volume = volumeSlider.value / 10;
        }
        else if (soundTrackObject != null) 
        {
            soundTrackObject.GetComponent<SoundTrackATO2>().maxVolume = volumeSlider.value / 10;
        }
    }
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        
    }
        public void openVolume()
    {
        if (volumeSliderOpen)
        {
            volumeSliderObj.SetActive(false);
            volumeSliderOpen = false;
            button.GetComponent<Image>().color = Color.white;
        }
        else if (!volumeSliderOpen)
        {
            volumeSliderObj.SetActive(true);
            volumeSliderOpen = true;
            button.GetComponent<Image>().color = Color.grey;
        }

    }

    public void takeSoundTrack()
    {
        soundTrackVolume = GameObject.FindGameObjectWithTag("SoundTrack").GetComponent<AudioSource>();
        soundTrackObject = GameObject.FindGameObjectWithTag("SoundTrack");
    }
}
