using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class MovCinematchRevolu : MonoBehaviour
{
    EntityStats entityStats;
    
    public float moveSpeed;
    public Transform target;
    Animator animatior;
    public GameObject soundWalk;
    bool start;

    
    // Start is called before the first frame update
    void Start()
    {
        entityStats = gameObject.GetComponent<EntityStats>();
        start = false;
        moveSpeed = entityStats.baseSpeed;
        animatior = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
       if (start)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
            if (transform.position == target.position) { start = false; }

            if (transform.position.x > target.position.x || transform.position.x < target.position.x || transform.position.y > target.position.y || transform.position.y < target.position.y)
            {
                soundWalk.GetComponent<AudioSource>().volume = 0.8f;
                if (transform.position.y > target.position.y)
                {
                    animatior.Play("WalkCima");
                    gameObject.GetComponent<SpriteRenderer>().flipX = false;
                }
                else if (transform.position.y < target.position.y)
                {
                    animatior.Play("WalkBaixo");
                    gameObject.GetComponent<SpriteRenderer>().flipX = false;
                }
                else if (transform.position.x < target.position.x)
                {
                    animatior.Play("WalkLado");
                    gameObject.GetComponent<SpriteRenderer>().flipX = false;

                }
                else if (transform.position.x > target.position.x)
                {
                    animatior.Play("WalkLado");
                    gameObject.GetComponent<SpriteRenderer>().flipX = true;

                }

            }
            else
            {
                soundWalk.GetComponent<AudioSource>().volume = 0;
                animatior.Play("Idle");
                gameObject.GetComponent<SpriteRenderer>().flipX = false;
            }
        }

        
    }
    
    public void mov()
    {
        start = true;
    }
}
