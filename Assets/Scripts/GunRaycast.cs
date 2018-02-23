using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunRaycast : MonoBehaviour {

	/* Raycast İşlemleri */
    [SerializeField] private float range = 2F;
	[SerializeField] private Camera cam;
	private RaycastHit hit;

	[SerializeField] private GameObject[] PuzzleObjects;

	void Start()
	{
		 PuzzleObjects = GameObject.FindGameObjectsWithTag("PuzzleObjects");	
	}

	void Update()
	{
		if(Input.GetMouseButton(0))
		{
			InteractPuzzle();
		}
	}
	
	void InteractPuzzle()
    {
		RaycastHit hit;
		if(Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range))
		{
//			Debug.Log(hit.transform.name);

			if(hit.collider.gameObject.name != null || hit.collider.gameObject.name != "")
			{
				if(hit.collider.gameObject.name.Contains("PuzzleObjectPrefab"))
				{
					for(int i = 0; i < PuzzleObjects.Length + 1; i++)
					{
						if(hit.collider.gameObject.name == "PuzzleObjectPrefab" + i)
						{
							print(hit.collider.gameObject.name);
							
							GameObject.Find(hit.collider.gameObject.name).GetComponent<EnterPuzzle>().LockThePuzzle();
							GameObject.Find(hit.collider.gameObject.name).GetComponent<EnterPuzzle>().TrailMoveStatu(hit.collider.gameObject.name);
						}
					}
				}
			}
        }
	}	
}

