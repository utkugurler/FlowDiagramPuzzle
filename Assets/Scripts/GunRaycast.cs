using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunRaycast : MonoBehaviour {

	private const string PUZZLE_OBJECTS_NAME = "PuzzleObject";

	// private EnterPuzzle enterPuzzle;

	private Camera cam;
	// Cisimler ile etkileşime girmek için gereken değişkenler.
    private RaycastHit hit;
    private float theDistance;
    public float range = 2;

	void Start()
	{
		cam = Camera.main; 	
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
        Vector3 forward = cam.transform.TransformDirection(Vector3.forward) * range;
        Debug.DrawRay(cam.transform.position, forward, Color.green);

        if (Physics.Raycast(cam.transform.position, (forward), out hit))
        {
            theDistance = hit.distance;
            if (theDistance < range)
            {
                print(theDistance + " " + hit.collider.gameObject.name);
            }
        }

		if(hit.collider.gameObject.name == PUZZLE_OBJECTS_NAME)
		{
			GameObject.Find(hit.collider.gameObject.name).GetComponent<EnterPuzzle>().LockThePuzzle();
			GameObject.Find("Trail").GetComponentInParent<TrailMovement>().enabled = true;//TODO Hatalı
		}
	}
}
