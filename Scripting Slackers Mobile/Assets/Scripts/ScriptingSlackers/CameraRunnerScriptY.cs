using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRunnerScriptY : MonoBehaviour
{

	[SerializeField]
	private float xMin;

	[SerializeField]
	private float yMin;

	[SerializeField]
	private float xMax;

	[SerializeField]
	private float yMax;

	public Transform target;

	void Start()
	{
		target = GameObject.FindWithTag("Player").transform;
	}


	void Update()
	{
		transform.position = new Vector3(Mathf.Clamp(target.position.x, xMin, xMax), Mathf.Clamp(target.position.y, yMin, yMax), transform.position.z);
	}



}
