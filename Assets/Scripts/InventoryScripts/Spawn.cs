﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject item;
    private Transform player;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    public void SpawnDropedItem() 
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        Vector2 playerPos = new Vector2(player.position.x, player.position.y - 3);
        item.SetActive(true);
        item.transform.position = (playerPos);
        //Instantiate(item, playerPos, Quaternion.identity);
    }
}
