using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PawnController : MonoBehaviour
{
	private Rigidbody _rigidBody;
	private bool _slowingDown;
	private Vector3 _initialPosition;
	private Quaternion _initialRotation;
	private int _updatesBelowAverage = 0;

	public GameObject forceApplicationPoint;
	public Vector3 currentSpeed;
	public float currentLength;
	public float force = 100f;

	void Start ()
	{
		_rigidBody = GetComponent<Rigidbody> ();
		_initialPosition = transform.position;
		_initialRotation = transform.rotation;
	}

	void Update()
	{
		currentSpeed = _rigidBody.velocity;
		currentLength = currentSpeed.magnitude;
		if (_slowingDown) {
			_rigidBody.AddForceAtPosition(currentSpeed * -0.7f, forceApplicationPoint.transform.position, ForceMode.Acceleration);

			if (currentLength < 0.3f && _updatesBelowAverage > 20) {
				transform.position = _initialPosition;
				transform.rotation = _initialRotation;
				_rigidBody.velocity = Vector3.zero;
				_rigidBody.angularVelocity = Vector3.zero;
				_slowingDown = false;
			} else if (currentLength < 0.3f) {
				_updatesBelowAverage++;
			}
			else {
				_updatesBelowAverage = 0;
			}

		}

	}

	void OnMouseDown ()
	{
		//_rigidBody.transform.RotateAround (rotationPivot.transform.position, Vector3.right, 45);
		var mouseClickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		var direction = gameObject.transform.position - mouseClickPosition;
		_rigidBody.AddForceAtPosition(direction.normalized * force, forceApplicationPoint.transform.position, ForceMode.Acceleration);

		DOVirtual.DelayedCall (2, () => _slowingDown = true);
		//_rigidBody.AddForce(Vector3.left * force, ForceMode.Acceleration);
		//_rigidBody.useGravity = true;
	}
}
