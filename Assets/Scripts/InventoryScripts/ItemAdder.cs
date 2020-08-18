using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAdder : MonoBehaviour
{
    public GameObject slotButton;
    private void Start()
    {
       // inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }

    // Update is called once per frame
    public void AddItem()
    {
       // for (int i = 0; i < inventory.slots.Length; i++) 
        //{
           // if (inventory.isFull[i] == false) 
           // {
                //inventory.isFull[i] = true;
                //inventory.ItemInHand = ItemName;
                //var item = Instantiate(slotButton, inventory.slots[i].transform);
               // item.GetComponent<Spawn>().item = gameObject;
                //break;
           // }
       // }
    }
}
