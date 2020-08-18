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
        Vector2 playerPos = new Vector2(player.position.x, player.position.y);
        item.SetActive(true);
        item.transform.Translate(playerPos);
        //Instantiate(item, playerPos, Quaternion.identity);
    }
}
