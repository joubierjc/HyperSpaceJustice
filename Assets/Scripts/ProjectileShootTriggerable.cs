using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileShootTriggerable : MonoBehaviour {

	[HideInInspector]
	public GameObject Projectile;
	[HideInInspector]
	public float AccuracyLoss;
	[HideInInspector]
	public float Damage;

	[SerializeField]
	private Transform shotSpawn;

	public void Shoot() {
		var rotationEuler = shotSpawn.rotation.eulerAngles;
		rotationEuler.z = Random.Range(rotationEuler.z - AccuracyLoss, rotationEuler.z + AccuracyLoss);
		var clonedBullet = Instantiate(Projectile, shotSpawn.position, Quaternion.Euler(rotationEuler));
		// more stuff with cloned bullet
	}
}
