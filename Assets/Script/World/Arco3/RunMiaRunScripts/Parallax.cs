using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    Material mat;
    float distance;

    [Range(0f, 1.5f)]
    public float speed = 0.02f;
    // Start is called before the first frame update
    void Start()
    {
        mat = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        distance += Time.deltaTime * speed ;
        mat.SetTextureOffset("_MainTex", Vector2.left * distance);
    }
}
