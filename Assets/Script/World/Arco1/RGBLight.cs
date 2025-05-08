using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class RGBLightATO1 : MonoBehaviour
{
    public Light2D luz;
    [SerializeField] private float changeInterval = 0.2f;

    // Start is called before the first frame update
    void Start()
    {
        luz = GetComponentInChildren<Light2D>();
        InvokeRepeating(nameof(ChangeLightColor), 0f, changeInterval);
    }

    private void ChangeLightColor()
    {
        var randomColor = new Color(Random.value, Random.value, Random.value);
        luz.color = randomColor;    
    }
   
}
