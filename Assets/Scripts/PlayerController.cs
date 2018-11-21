using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour {

	[SerializeField]
	private float speed = 35f;
	[SerializeField]
	private float movementLerp = 0.5f;
	[SerializeField]
	private Transform aiming;

	[Header("Combat settings")]
	[SerializeField]
	private WeaponCoolDown generatorWeapon;
	[SerializeField]
	private WeaponCoolDown spenderWeapon;
	[SerializeField]
	private WeaponCoolDown specialWeapon;

	[Header("Roll settings")]
	[SerializeField]
	private float rollDuration = 0.25f;
	[SerializeField]
	private float rollCoolDown = 0.2f;
	[SerializeField]
	private float rollSpeed = 55f;
	[SerializeField]
	private float rollSlowFactor = 0.1f;

	private Vector3 movement;

	private bool dodging = false;
	private bool primaryShooting = false;
	private bool secondaryShooting = false;

	private Rigidbody rb;
	private Camera cam;
	private new Transform transform;

	private void Awake() {
		rb = GetComponent<Rigidbody>();
		cam = Camera.main;
		transform = GetComponent<Transform>();
	}

	private void Update() {

		// AIMING
		var direction = Input.mousePosition - cam.WorldToScreenPoint(transform.position);
		var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
		aiming.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

		// MOVEMENT
		movement = GetDirection();

		// DODGE
		if (Input.GetButtonDown("Jump") && !dodging) {
			StartCoroutine(DodgeCoroutine());
		}

	}

	private void FixedUpdate() {
		if (dodging) {
			return;
		}

		if (movement.magnitude > 1f) {
			movement.Normalize();
		}

		rb.velocity = Vector3.Lerp(rb.velocity, movement * speed, movementLerp);
	}

	private Vector3 GetDirection() {
		return new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
	}

	IEnumerator DodgeCoroutine() {
		dodging = true;
		// TODO start bullet/missile/laser immunity

		var movement = GetDirection();
		if (movement.x == 0f && movement.y == 0f) {
			movement = Vector3.right;
		}

		rb.velocity = movement.normalized * rollSpeed;

		yield return new WaitForSeconds(rollDuration);

		rb.velocity *= rollSlowFactor;

		// TODO: stop bullet/missile/laser immunity

		yield return new WaitForSeconds(rollCoolDown);

		dodging = false;
	}
}
