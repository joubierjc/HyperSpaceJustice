using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody))]
public class HomingProjectile : Projectile {

	[SerializeField]
	private EntityType searchFilter;
	[SerializeField]
	private float rotationSpeed = 60f;
	[SerializeField]
	private float searchRadius = 5f;
	[SerializeField]
	private float searchRefreshRate = 0.1f;

	private Transform target;

	private void FixedUpdate() {
		rb.velocity = transform.right * speed;
		if (target != null) {
			var vectorToTarget = target.position - transform.position;
			var angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
			var to = Quaternion.AngleAxis(angle, Vector3.forward);
			transform.rotation = Quaternion.RotateTowards(transform.rotation, to, rotationSpeed * Time.fixedDeltaTime);
		}
	}

	protected override void OnEnable() {
		base.OnEnable();
		StartCoroutine(SearchClosestCoroutine());
	}

	IEnumerator SearchClosestCoroutine() {
		while (enabled) {
			float minDist = searchRadius;
			Vector3 currentPos = transform.position;
			if (target != null && Vector3.Distance(currentPos, target.position) > minDist) {
				target = null;
			}
			foreach (var item in EntityTracker.Find(searchFilter)) {
				float dist = Vector3.Distance(item.transform.position, currentPos);
				if (dist < minDist) {
					target = item.transform;
					minDist = dist;
				}
			}
			yield return new WaitForSeconds(searchRefreshRate);
		}
	}
}
