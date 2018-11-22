using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileShootTriggerable : MonoBehaviour {

	[SerializeField]
	private Transform shotSpawn;

	private Weapon weaponRef;
	private LayerMask projectileLayerRef;

	public void Init(Weapon weapon) {
		weaponRef = weapon;
		projectileLayerRef = weapon.ProjectileLayerRef;
	}

	public void Shoot() {
		var rotationEuler = shotSpawn.rotation.eulerAngles;
		rotationEuler.z = Random.Range(rotationEuler.z - weaponRef.AccuracyLoss, rotationEuler.z + weaponRef.AccuracyLoss);
		var clonedBullet = Instantiate(weaponRef.Projectile, shotSpawn.position, Quaternion.Euler(rotationEuler));

		var projectile = clonedBullet.GetComponent<Projectile>();
		projectile.Init(weaponRef, projectileLayerRef);
		// more stuff with cloned bullet
	}
}
