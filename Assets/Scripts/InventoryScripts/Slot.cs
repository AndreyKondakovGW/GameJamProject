using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
    private Inventory inventory;
    public int i;
    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }
    private void Update()
    {
        if (transform.childCount <= 0) 
        {
            inventory.isFull[i] = false;
        }
    }
    public void DropItem() 
    {
        foreach (Transform child in transform) 
        {
            child.GetComponent<Spawn>().SpawnDropedItem();
            GameObject.Destroy(child.gameObject);
        }
    }

    public void TakeIteminHand()
    {
       foreach (Transform child in transform) 
        {
            var itemname = child.GetComponent<Spawn>().item.GetComponent<PickUp>().ItemName;
            inventory.ItemInHand = itemname;
            inventory.LastItem = child.gameObject;
        } 
    }
}
