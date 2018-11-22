using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody))]
public class Projectile : MonoBehaviour {

	[SerializeField]
	private float speed = 65f;
	[SerializeField]
	private float timeBeforeDisable = 5f;
	[SerializeField]
	private AdditionnalProjectile[] onInitSpawn;
	[SerializeField]
	private AdditionnalProjectile[] onDisableSpawn;

	private Weapon weaponRef;
	private LayerMask projectileLayerRef;

	private Rigidbody rb;
	private new Transform transform;

	private void Awake() {
		rb = GetComponent<Rigidbody>();
		transform = GetComponent<Transform>();
	}

	private void OnEnable() {
		rb.velocity = transform.right * speed;
		StartCoroutine(DisableCoroutine());
	}

	private void OnDisable() {
		for (int i = 0; i < onDisableSpawn.Length; i++) {
			var clonedBullet = Instantiate(onDisableSpawn[i].Projectile, onDisableSpawn[i].ShotSpawn.position, onDisableSpawn[i].ShotSpawn.rotation);
			var projectile = clonedBullet.GetComponent<Projectile>();
			projectile.Init(weaponRef, projectileLayerRef);
		}
	}

	IEnumerator DisableCoroutine() {
		yield return new WaitForSeconds(timeBeforeDisable);
		Destroy(gameObject); // TODO remplacer par disable, après les objects pool
	}

	public void Init(Weapon weapon, LayerMask projectileLayer) {
		weaponRef = weapon;
		projectileLayerRef = projectileLayer;
		for (int i = 0; i < onInitSpawn.Length; i++) {
			var clonedBullet = Instantiate(onInitSpawn[i].Projectile, onInitSpawn[i].ShotSpawn.position, onInitSpawn[i].ShotSpawn.rotation);
			var projectile = clonedBullet.GetComponent<Projectile>();
			projectile.Init(weaponRef, projectileLayerRef);
		}
	}


}
