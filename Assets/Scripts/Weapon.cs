using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : ScriptableObject {
	public GameObject Projectile;
	public float WindUpTime;
	public float AttackRate;
	public float AccuracyLoss;

	public virtual void Shoot(Transform origin) {
		var rotationEuler = origin.rotation.eulerAngles;
		rotationEuler.z = Random.Range(rotationEuler.z - AccuracyLoss, rotationEuler.z + AccuracyLoss);

		Instantiate(Projectile, origin.position, Quaternion.Euler(rotationEuler));
	}
}
