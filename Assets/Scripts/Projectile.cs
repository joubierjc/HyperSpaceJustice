using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Projectile : MonoBehaviour {

	[SerializeField]
	private float speed = 65f;
	[SerializeField]
	private float timeBeforeDisable = 5f;

	private Rigidbody rb;
	private new Transform transform;

	private void Awake() {
		rb = GetComponent<Rigidbody>();
		transform = GetComponent<Transform>();
	}

	private void OnEnable() {
		rb.velocity = transform.TransformVector(Vector3.right) * speed;
		StartCoroutine(DisableCoroutine());
	}


	IEnumerator DisableCoroutine() {
		yield return new WaitForSeconds(timeBeforeDisable);
		Destroy(gameObject); // TODO remplacer par disable, après les objects pool
	}
}
