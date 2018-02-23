using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzlePath : MonoBehaviour {

	//[SerializeField] private GameObject TrailObject; 
	[SerializeField] private GameObject[] ObjectPaths;

	// Use this for initialization
	void Start () {
		
	}

	public void GetTrail(string TrailObject)
	{
		TrailRenderer trail = GameObject.Find("Puzzles/" + TrailObject + "/Trail").GetComponent<TrailRenderer>();
	}

	/* public void FindPaths(string TrailObject)
	{
		GameObject g = GameObject.Find("Puzzles/" + TrailObject + "/Paths/");
		int count = g.transform.childCount;
		print(count + "sayi");
		for(int i = 1; i < count; i++)
		{
			print(i);
			ObjectPaths[i - 1] = GameObject.Find("Puzzles/" + TrailObject + "/Paths/" + i);
		}
	} */
	
	// Update is called once per frame
	void Update () {
		
	}

	public int count = 1;
	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.name == count.ToString())
		{
			print("Doğru!");
			count++;
		}
		else
		{
			print("Yanlış");
		}
	}
}
