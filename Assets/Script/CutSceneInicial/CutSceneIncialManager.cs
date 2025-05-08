using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CutSceneIncialManager : MonoBehaviour
{
    public int cooldown;
    public int activeImage;
    public Image image;
    public List <Sprite> sprites;
    public AudioSource audioSource;
    public List<AudioClip> clip;
    public Button buttonNextImage;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(NextImage());
   
    }

    private void Update()
    {
        if (activeImage >= sprites.Count) { SceneManager.LoadScene("StartWorldProto"); }
    }

    public IEnumerator NextImage()
    {
        buttonNextImage.gameObject.SetActive(false);
        activeImage++;
        StartCoroutine(fade(true));
        yield return new WaitForSeconds(cooldown);
        image.sprite = sprites[activeImage];
        StartCoroutine(fade(false));
        if (clip[activeImage] != null)
        {
            audioSource.clip = clip[activeImage];
            audioSource.Play();
        }

        yield return new WaitForSeconds(cooldown);

        buttonNextImage.gameObject.SetActive(true);
        yield return null;
    }

    public void StartButtonCoroutine()
    {
       StartCoroutine(NextImage());
        Debug.Log("Botao aperdainho");
    }

 

    IEnumerator fade(bool fadeAway)
    {
        // fade from opaque to transparent
        if (fadeAway)
        {
            // loop over 1 second backwards
            for (float i = 1; i > 0; i -= Time.deltaTime)
            {
                // set color with i as alpha
                image.color = new Color(1, 1, 1, i);
                yield return null;
            }
        }
        // fade from transparent to opaque
        else
        {
            // loop over 1 second
            for (float i = 0; i < 1; i += Time.deltaTime)
            {
                // set color with i as alpha
                image.color = new Color(1, 1, 1, i);
                yield return null;
            }
        }
    }
}
