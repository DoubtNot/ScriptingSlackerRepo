using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnEnter : MonoBehaviour
{
	private void OnTriggerEnter2D(Collider2D collider)
	{

		if (collider.transform.tag == "Break")
		{
			Destroy(collider.gameObject);
		}

	}
}
