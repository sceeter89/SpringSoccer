using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PawnCameraController : MonoBehaviour
{
	private bool _isMousePressed;

	public float cameraRotationSpeed;
	public GameObject pawn;


	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{		
		if (Input.GetMouseButtonDown (1)) {
			_isMousePressed = true;
		}
		if (Input.GetMouseButtonUp (1)) {
			_isMousePressed = false;
		}
		if (_isMousePressed) {
			transform.RotateAround (pawn.GetComponent<Transform>().position, Vector3.up, Input.GetAxis ("Mouse X") * cameraRotationSpeed);
		}
	}
}
