using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class EnterPuzzle : MonoBehaviour {

	public GameObject GetPuzzleCamera;

	private const string FPS_CONTROLLER_NAME = "FPSController";

	public void LockThePuzzle()
	{
		GameObject.Find(FPS_CONTROLLER_NAME).GetComponent<FirstPersonController>().enabled = false;
		Camera.main.transform.position = GetPuzzleCamera.gameObject.transform.position;
		Camera.main.transform.rotation = new Quaternion(0,0,0,0);
		Camera.main.fieldOfView = 13.0f;
	}
}
