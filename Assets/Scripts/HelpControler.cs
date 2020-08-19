using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpControler : MonoBehaviour
{
    public bool HelpisOpen;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            if (HelpisOpen)
            {
                HelpisOpen = false;
                gameObject.transform.GetChild(0).gameObject.SetActive(false);
            }else
            {
                HelpisOpen = true;
                gameObject.transform.GetChild(0).gameObject.SetActive(true);
            }
        }
    }
}
