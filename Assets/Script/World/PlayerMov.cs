using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class PlayerMov : MonoBehaviour
{

    EntityStats entityStats;
    public bool normalMov;
    public float moveSpeed;
    private Vector2 moveDirection;
    Animator animatior;
    public GameObject soundWalk;

    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        entityStats = gameObject.GetComponent<EntityStats>();
        rb = gameObject.GetComponent<Rigidbody2D>();
        moveSpeed = entityStats.baseSpeed;
        animatior = gameObject.GetComponent<Animator>();
       
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (DialogueManager.Instance.isDialogue || DialogueManager.Instance.isPuzzle ) { animatior.Play("Idle");
            soundWalk.GetComponent<AudioSource>().Stop();
        }
        else { 
        Mov(); 

        }
    }


    void Mov()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        moveDirection = new Vector2(horizontal, vertical);
            //gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(horizontal * moveSpeed * Time.deltaTime, vertical * moveSpeed * Time.deltaTime));      
            Vector3 movePosition = (moveSpeed * Time.fixedDeltaTime * moveDirection.normalized) + rb.position;
            rb.MovePosition(movePosition);


        //////Movimentto diagonal
        //   if ((horizontal > 0 || horizontal < 0) && (vertical > 0 || vertical < 0))
        //   {
        //      moveSpeed = entityStats.baseSpeed * 0.66f;
        //       //gameObject.GetComponent<Rigidbody2D>().Sleep();
        //   }
        //   else
        //   {
        //       moveSpeed = entityStats.baseSpeed;
        //}

        if (horizontal > 0 || horizontal < 0 || vertical > 0 || vertical < 0)
        {
          soundWalk.GetComponent<AudioSource>().volume = 0.8f;
            if (vertical > 0)
            {
                animatior.Play("WalkCima");
                gameObject.GetComponent<SpriteRenderer>().flipX = false;
            }
            else if (vertical < 0)
            { 
                animatior.Play("WalkBaixo");
                gameObject.GetComponent<SpriteRenderer>().flipX = false;
            }
            else if (horizontal > 0)
            {
                animatior.Play("WalkLado");
                gameObject.GetComponent<SpriteRenderer>().flipX = false ;
                
            }
            else if (horizontal < 0)
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


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            SceneManager.LoadScene("Battle");
        }
    }
}
