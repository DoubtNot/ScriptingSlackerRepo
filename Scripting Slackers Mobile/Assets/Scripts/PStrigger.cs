using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PStrigger : MonoBehaviour
{

    public GameObject bloodSpill;
   
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameObject spill = Instantiate(bloodSpill) as GameObject;
            spill.transform.position = transform.position;
            Destroy(this.gameObject);
        }
    }
}
