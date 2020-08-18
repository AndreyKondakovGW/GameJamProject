using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCharcter : MonoBehaviour
{
    public GameObject target;
    // Start is called before the first frame update
    public void Move()
    {
        GameObject.FindGameObjectWithTag("Player").transform.Translate(new Vector2(target.transform.position.x,target.transform.position.y));
    }
}
