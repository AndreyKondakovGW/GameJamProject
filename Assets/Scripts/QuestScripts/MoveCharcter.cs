using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCharcter : MonoBehaviour
{
    public GameObject target;
    public GameObject player;
    // Start is called before the first frame update
    public void Move()
    {
        if (player == null)
        {
            GameObject.FindGameObjectWithTag("Player").transform.position = (new Vector2(target.transform.position.x,target.transform.position.y));
        }
        else
        {
            player.transform.position = (new Vector2(target.transform.position.x,target.transform.position.y));  
        }
    }
}
