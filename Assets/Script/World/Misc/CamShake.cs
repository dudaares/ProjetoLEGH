using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CamShake : MonoBehaviour
{
    public static CamShake Instance { get; private set; }

    public Transform cameraTransform;
    public bool start;
    public AnimationCurve curve;
    public float duration = 1f;



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
    // Start is called before the first frame update
   
    public void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (start) 
        {
            start = false;
            StartCoroutine(Shaking());
        }
    }

    IEnumerator Shaking()
    {
        Vector3 startPosition = cameraTransform.position;
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime; 
            float streng = curve.Evaluate(elapsedTime/duration);
            cameraTransform.position = startPosition + Random.insideUnitSphere * streng;


            yield return null;
        }
        cameraTransform.position = startPosition;
    }
}
