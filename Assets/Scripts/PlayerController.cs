using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour {

	[SerializeField]
	private float speed = 25f;
	[SerializeField]
	private float rollDuration = 0.5f;
	[SerializeField]
	private float rollSpeed = 40f;

	private Vector3 movement;

	private bool isRolling = false;
	private float rollTimer = 0f;

	private Rigidbody rb;
	private Camera cam;
	private new Transform transform;

	private void Awake() {
		rb = GetComponent<Rigidbody>();
		cam = Camera.main;
		transform = GetComponent<Transform>();
	}

	private void Update() {
		// TODO LATER: custom inputs
		var direction = Input.mousePosition - cam.WorldToScreenPoint(transform.position);
		var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward); // TODO rotate l'enfant qui s'occupera du ShotSpawn
	}

	private void FixedUpdate() {
		// TODO LATER: custom inputs
		if (isRolling) {
			rollTimer += Time.fixedDeltaTime;
			if (rollTimer >= rollDuration) {
				isRolling = false;
			}
			return;
		}

		isRolling = Input.GetButton("Jump");

		var horizontal = Input.GetAxis("Horizontal");
		var vertical = Input.GetAxis("Vertical");

		movement = new Vector3(horizontal, vertical);
		if (movement.magnitude > 1f) {
			movement.Normalize();
		}

		if (isRolling) {
			rollTimer = 0f;
			if (movement.x == 0f && movement.y == 0f) {
				movement.x = 1f;
			}
		}

		rb.velocity = isRolling ? movement.normalized * rollSpeed : movement * speed;
	}

}
