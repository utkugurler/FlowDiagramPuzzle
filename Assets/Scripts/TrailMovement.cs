using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailMovement : MonoBehaviour {

	public float x_Tranform = 0.5f;
	public float y_Tranform = 0.5f;

	void Update () 
	{
		/* Cubeline x, y coordinats movement */
		if(Input.GetKey(KeyCode.UpArrow))
		{	
			transform.Translate(0, x_Tranform * Time.deltaTime * 1.0f, 0);
		}
		if(Input.GetKey(KeyCode.DownArrow))
		{
			transform.Translate(0, -(x_Tranform) * Time.deltaTime * 1.0f, 0);
		}

		if(Input.GetKey("left"))
		{
			//print("left");
			transform.Translate(-(y_Tranform) * Time.deltaTime * 1.0f, 0, 0);
		}
		if(Input.GetKey("right"))
		{
			//print("right");
			transform.Translate((y_Tranform) * Time.deltaTime * 1.0f, 0, 0);
		} 
	}
}
