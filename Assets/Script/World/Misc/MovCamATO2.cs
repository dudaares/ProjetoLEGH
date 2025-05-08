using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MovCamATO2 : MonoBehaviour
{
    GameObject player;
    private Vector3 targetTransform;

    [Header("Mapa geral")]
    public Transform  limitY;
    public Transform limitYNegativo;
    public Transform limitX;
    public Transform limitXNegativo;


    [Header("Metro")]
    public Transform limitYMetro;
    public Transform limitXMetro;
    public Transform limitXMetro2;
    public Transform lockMetro;

    [Header("Castle")]
    public bool isCastle;
    public Transform lockCastleY;
    public Transform lockCastleY2;


    
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if (isCastle)
        {
            targetTransform =  new Vector3( lockCastleY2.position.x, player.transform.position.y);
        }
       
    }

    // Update is called once per frame
    void FixedUpdate()
    {
      
     
        transform.position = Vector3.Lerp(this.transform.position, new Vector3(targetTransform.x, targetTransform.y, -10), 5 * Time.deltaTime);
    }
    private void Update()
    {
        if (isCastle)
        {
            gameObject.GetComponent<Camera>().orthographicSize = 4.72f;
            
            if (player.transform.position.y < lockCastleY.position.y)
            {
                targetTransform = lockCastleY.transform.position;
            }
            else if (player.transform.position.y > lockCastleY2.position.y) 
            {
                targetTransform = lockCastleY2.transform.position;
            }
            else
            {
                targetTransform.y = player.transform.position.y;
            }
        }
        else { 
        if (player.transform.position.x > limitXMetro.position.x && player.transform.position.y > limitYMetro.position.y && player.transform.position.x < limitXMetro2.position.x)
        {
            this.transform.position = lockMetro.position;

            gameObject.GetComponent<Camera>().orthographicSize = 4.11f;
        }
        else if (player.transform.position.x > limitX.position.x)
            {
                targetTransform.x = limitX.position.x;
                targetTransform.y = player.transform.position.y;
            }
            else if (player.transform.position.x < limitXNegativo.position.x)
            {
                targetTransform.x = limitXNegativo.position.x;
                targetTransform.y = player.transform.position.y;
            }
            else if (player.transform.position.y > limitY.position.y)
            {
                targetTransform.y = limitY.position.y;
                targetTransform.x = player.transform.position.x;
            }
            else if (player.transform.position.y < limitYNegativo.position.y)
            {
                targetTransform.y = limitYNegativo.position.y;
                targetTransform.x = player.transform.position.x;
            }
            else { targetTransform = player.transform.position; gameObject.GetComponent<Camera>().orthographicSize = 6.5f; }
        }
    }
}
