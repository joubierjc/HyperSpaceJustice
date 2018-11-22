using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Weapons/New Generator Weapon")]
public class GeneratorWeapon : Weapon {

	public float EnergyGenAmout = 10f;

	private ProjectileShootTriggerable projShoot;

	public override void Init(GameObject obj) {
		projShoot = obj.GetComponent<ProjectileShootTriggerable>();

		projShoot.Init(this);
	}

	public override void Trigger() {
		projShoot.Shoot();
	}
}
