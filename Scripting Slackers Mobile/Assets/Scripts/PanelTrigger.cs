using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelTrigger : MonoBehaviour
{

    public GameObject mapPanel;
   
    void Start()
    {
        mapPanel.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player") 
        {
            mapPanel.SetActive(true);
        }
    }

}
