using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PawnController : MonoBehaviour
{
	private Rigidbody _rigidBody;
	private MeshFilter _meshFilter;

	public GameObject forceApplicationPoint;
	public float currentRotation = 0f;
	public float force = 100f;

	void Start ()
	{
		_rigidBody = GetComponent<Rigidbody> ();
		_meshFilter = GetComponent<MeshFilter> ();
	}

	void OnMouseDown ()
	{
		//_rigidBody.transform.RotateAround (rotationPivot.transform.position, Vector3.right, 45);

		//_rigidBody.AddForceAtPosition(Vector3.left * force, forceApplicationPoint.transform.position, ForceMode.Acceleration);
		_rigidBody.AddForce(Vector3.left * force, ForceMode.Acceleration);
		//_rigidBody.useGravity = true;
	}
}
