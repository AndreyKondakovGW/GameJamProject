﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public string ItemName;
    private Inventory inventory;
    public GameObject slotButton;
    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if ((other.CompareTag("Player"))&&(Input.GetKeyDown(KeyCode.E))) 
        {
            for (int i = 0; i < inventory.slots.Length; i++) 
            {
                if (inventory.isFull[i] == false) 
                {
                    Debug.Log(gameObject);
                    inventory.isFull[i] = true;
                    var item = Instantiate(slotButton, inventory.slots[i].transform);
                    item.GetComponent<Spawn>().item = gameObject;
                    gameObject.SetActive(false);
                    break;
                }
            }
        }
    }
}
