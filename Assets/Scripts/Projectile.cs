using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody))]
public class Projectile : MonoBehaviour {

	[SerializeField]
	protected float speed = 65f;
	[SerializeField]
	protected float timeBeforeDisable = 5f;
	[SerializeField]
	protected AdditionnalProjectile[] onInitSpawn;
	[SerializeField]
	protected AdditionnalProjectile[] onDisableSpawn;

	protected Weapon weaponRef;

	protected Rigidbody rb;
	protected new Transform transform;

	protected virtual void Awake() {
		rb = GetComponent<Rigidbody>();
		transform = GetComponent<Transform>();
	}

	protected virtual void OnEnable() {
		rb.velocity = transform.right * speed;
		StartCoroutine(DisableCoroutine());
	}

	protected virtual void OnDisable() {
		for (int i = 0; i < onDisableSpawn.Length; i++) {
			var clonedBullet = Instantiate(onDisableSpawn[i].Projectile, onDisableSpawn[i].ShotSpawn.position, onDisableSpawn[i].ShotSpawn.rotation);
			var projectile = clonedBullet.GetComponent<Projectile>();
			projectile.Init(weaponRef);
		}
	}

	protected virtual IEnumerator DisableCoroutine() {
		yield return new WaitForSeconds(timeBeforeDisable);
		Destroy(gameObject); // TODO remplacer par disable, après les objects pool
	}

	public virtual void Init(Weapon weapon) {
		weaponRef = weapon;

		gameObject.layer = LayerMask.NameToLayer(weapon.ProjectileLayerRef);

		for (int i = 0; i < onInitSpawn.Length; i++) {
			var clonedBullet = Instantiate(onInitSpawn[i].Projectile, onInitSpawn[i].ShotSpawn.position, onInitSpawn[i].ShotSpawn.rotation);
			var projectile = clonedBullet.GetComponent<Projectile>();
			projectile.Init(weaponRef);
		}
	}

}
