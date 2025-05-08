using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MovCam : MonoBehaviour
{
    public GameObject targetObject;

    public List<Transform> corredorLimits;
    public List<Transform> cityLimits;
    public List<Transform> Puzzle1Limits;
    public List<Transform> Puzzle2Limits;
    public List<Transform> Puzzle3Limits;
    public List<Transform> bossRoomLimits;
    Vector3 targetTransform;

    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        targetObject = player;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Camera do primeiro corredor
        if (player.transform.position.y > corredorLimits[2].position.y)
        {       
            targetTransform = new Vector3(targetObject.transform.position.x, gameObject.transform.position.y, -10);
            if (player.transform.position.x < corredorLimits[0].position.x )
            {
                targetTransform = new Vector3(gameObject.transform.position.x, corredorLimits[0].transform.position.y, -10);
            }
            else if (player.transform.position.x > corredorLimits[1].position.x)
            {
                targetTransform = new Vector3(gameObject.transform.position.x, corredorLimits[1].transform.position.y, -10);

            }
        }
        //puzzle1
        else if (player.transform.position.x > Puzzle1Limits[0].position.x && player.transform.position.y < Puzzle1Limits[1].position.y)
        {
            targetTransform = new Vector3(Puzzle1Limits[2].position.x, Puzzle1Limits[2].position.y, -10);
            gameObject.GetComponent<Camera>().orthographicSize = 6;
        }
        //puzzle2
        else if (player.transform.position.x < Puzzle2Limits[0].position.x && player.transform.position.y < Puzzle2Limits[1].position.y)
        {
            targetTransform = new Vector3(Puzzle2Limits[2].position.x, Puzzle2Limits[2].position.y, -10);
            gameObject.GetComponent<Camera>().orthographicSize = 6;
        }
        //BossRoom
        else if (player.transform.position.x < bossRoomLimits[0].position.x && player.transform.position.y < bossRoomLimits[1].position.y)
        {
            targetTransform = new Vector3(bossRoomLimits[2].position.x, bossRoomLimits[2].position.y, -10);

        }
        //puzzle3
        else if (player.transform.position.x < Puzzle3Limits[0].position.x && player.transform.position.y < Puzzle3Limits[1].position.y)
        {
            targetTransform = new Vector3(Puzzle3Limits[2].position.x, Puzzle3Limits[2].position.y, -10);
            gameObject.GetComponent<Camera>().orthographicSize = 6.5f;
        }
        
        else if (player.transform.position.x < cityLimits[0].position.x || player.transform.position.x > cityLimits[1].position.x)
        {
            //Camera da cidade X
            targetTransform = new Vector3(gameObject.transform.position.x, targetObject.transform.position.y, -10);
            Debug.Log("X TA TRAVADO");
        }
        else if (player.transform.position.y > cityLimits[2].position.y || player.transform.position.y < cityLimits[3].position.y)
        {
            //Camera da cidade Y
            targetTransform = new Vector3(targetObject.transform.position.x, gameObject.transform.position.y, -10);
            Debug.Log("Y TA TRAVADO");
        }
        else if ((player.transform.position.y > cityLimits[2].position.y || player.transform.position.y < cityLimits[3].position.y) && (player.transform.position.x < cityLimits[0].position.x || player.transform.position.x > cityLimits[1].position.x))
        {
            //Camera da cidade X e Y
            targetTransform = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, -10);
        }
        //Camera livre
        else { targetTransform = player.transform.position; gameObject.GetComponent<Camera>().orthographicSize = 6.5f; }


        transform.position = Vector3.Lerp(this.transform.position, new Vector3(targetTransform.x, targetTransform.y, -10), 5 * Time.deltaTime);
    }
}
