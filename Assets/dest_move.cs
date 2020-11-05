using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dest_move : MonoBehaviour
{
	public bool Move = false;

	public Vector3 DestPos;
	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		if (!Move)
			return;

		transform.position = Vector3.Lerp(transform.position, DestPos, Time.deltaTime*5f);

		if (Vector3.Distance(transform.position, DestPos) < .1f)
			Move = false;
	}
}
