using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class EnterPuzzle : MonoBehaviour {

	public GameObject GetPuzzleCamera;

	private const string FPS_CONTROLLER_NAME = "FPSController";
	private static float fieldOfView;
	private static Vector3 cameraMainTransform;
	private static Quaternion cameraMainRotation;
	private static bool enterPuzzleFlag = false;

	void Start()
	{
	}

	private void SetFirstCameraSettings()
	{
		cameraMainTransform = Camera.main.transform.position;
		cameraMainRotation = Camera.main.transform.rotation;
		fieldOfView = Camera.main.fieldOfView;
	}

	private void GetFirstCameraSettings()
	{
		GameObject.Find(FPS_CONTROLLER_NAME).GetComponent<FirstPersonController>().enabled = true;
		Camera.main.transform.position = cameraMainTransform;
		Camera.main.transform.rotation = cameraMainRotation;
		Camera.main.fieldOfView = fieldOfView;
		enterPuzzleFlag = false;
		GameObject.Find(TrailHitObjectName).GetComponentInChildren<TrailMovement>().enabled = enterPuzzleFlag; // Puzzle' dan çıkınca trail move pasif ediliyor
	}

	public void LockThePuzzle()
	{
		SetFirstCameraSettings();
		GameObject.Find(FPS_CONTROLLER_NAME).GetComponent<FirstPersonController>().enabled = false;
		Camera.main.transform.position = GetPuzzleCamera.gameObject.transform.position;
		Camera.main.transform.rotation = GetPuzzleCamera.gameObject.transform.rotation;
		Camera.main.fieldOfView = 39.0f;
		enterPuzzleFlag = true;
	}
	
	void Update()
	{
		if(enterPuzzleFlag == true && Input.GetKeyDown(KeyCode.E))
		{
			GetFirstCameraSettings();
		}
	}

	static string TrailHitObjectName;
	public void TrailMoveStatu(string TrailHit)
	{
		TrailHitObjectName = TrailHit;
		GameObject.Find(TrailHit).GetComponentInChildren<TrailMovement>().enabled = enterPuzzleFlag;
		GameObject.Find(TrailHit).GetComponentInChildren<PuzzlePath>().GetTrail(TrailHit);
	}
}
