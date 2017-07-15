using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PawnController : MonoBehaviour
{
	private Rigidbody _rigidBody;
	private bool _slowingDown;

	public GameObject forceApplicationPoint;
	public Vector3 currentSpeed;
	public float force = 100f;

	void Start ()
	{
		_rigidBody = GetComponent<Rigidbody> ();
	}

	void Update()
	{
		currentSpeed = _rigidBody.velocity;

		if (_slowingDown) {
			_rigidBody.AddForceAtPosition(currentSpeed * -0.7f, forceApplicationPoint.transform.position, ForceMode.Acceleration);
		}

	}

	void OnMouseDown ()
	{
		//_rigidBody.transform.RotateAround (rotationPivot.transform.position, Vector3.right, 45);

		_rigidBody.AddForceAtPosition(Vector3.left * force, forceApplicationPoint.transform.position, ForceMode.Acceleration);
		_slowingDown = true;
		//_rigidBody.AddForce(Vector3.left * force, ForceMode.Acceleration);
		//_rigidBody.useGravity = true;
	}
}
