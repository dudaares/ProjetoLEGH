using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyBehavior : MonoBehaviour
{

    //codigo pelo gptesco
    public float sensitivity = 0.1f; // Sensibilidade para detectar movimento
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        // Verifica se o objeto está se movendo mais no eixo X
        if (Mathf.Abs(rb.velocity.x) > sensitivity && Mathf.Abs(rb.velocity.x) > Mathf.Abs(rb.velocity.y))
        {
            // Libera o movimento no eixo X e trava no eixo Y
            rb.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
        }
        else if (Mathf.Abs(rb.velocity.y) > sensitivity && Mathf.Abs(rb.velocity.y) > Mathf.Abs(rb.velocity.x))
        {
            // Libera o movimento no eixo Y e trava no eixo X
            rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
        }
        else
        {
            // Libera ambos os eixos se não houver movimento significativo
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
    }
}
