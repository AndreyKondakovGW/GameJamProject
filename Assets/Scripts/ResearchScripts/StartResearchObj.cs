using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartResearchObj : MonoBehaviour
{
    public GameObject ResearchPanel;
    public Sprite ObjView;

    public void StartResarch()
    {
        ResearchPanel.SetActive(true);
        ResearchPanel.transform.Find("Image").GetComponent<Image>().sprite = ObjView;
    }
}
