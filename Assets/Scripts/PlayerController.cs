using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour {

	[SerializeField]
	private float speed = 25f;

	private Rigidbody rb;

	private void Awake() {
		rb = GetComponent<Rigidbody>();
	}

	private void FixedUpdate() {
		float horizontal = Input.GetAxis("Horizontal");
		float vertical = Input.GetAxis("Vertical");

		rb.velocity = new Vector3(horizontal, vertical).normalized * speed;
	}

}
