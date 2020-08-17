using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryScriptControler : MonoBehaviour
{
    public bool InventoryisOpen;
    public GameObject InventoryPanel;

    public GameObject CharacterSwicher;


    public void OnSwicher()
    {
        CharacterSwicher.SetActive(true);
    }

    public void OffSwicher()
    {
        CharacterSwicher.SetActive(false);
    }  
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (InventoryisOpen)
            {
                InventoryPanel.SetActive(false);
                InventoryisOpen = false;
            }
            else
            {
                InventoryPanel.SetActive(true);
                InventoryisOpen = true;  
            }
        }
    }
}
