using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Weapons/New Generator Weapon")]
public class GeneratorWeapon : Weapon {

	public float EnergyGenAmout = 10f;

	public override void Trigger(Transform shotSpawn) {
		var rotationEuler = shotSpawn.rotation.eulerAngles;
		rotationEuler.z = Random.Range(rotationEuler.z - AccuracyLoss, rotationEuler.z + AccuracyLoss);
		var clonedBullet = Instantiate(Projectile, shotSpawn.position, Quaternion.Euler(rotationEuler));

		var projectile = clonedBullet.GetComponent<Projectile>();
		projectile.Init(this);
	}
}
