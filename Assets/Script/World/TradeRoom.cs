using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TradeRoom : MonoBehaviour
{

    public Transform roomPrincipal;
    public Transform roomSecundary;


    public GameObject camera;
    Transform nextRoom;
    // Start is called before the first frame update
    void Start()
    {
        nextRoom = roomSecundary;
        camera = GameObject.FindGameObjectWithTag("MainCamera");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" )
        {
            camera.transform.position = new Vector3(nextRoom.transform.position.x, nextRoom.transform.position.y, -10);
            if (nextRoom == roomSecundary )
            {
                nextRoom = roomPrincipal;
            }
            else if (nextRoom == roomPrincipal)
            {
                nextRoom = roomSecundary;
            }
        }
    }

}
