using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : ScriptableObject {
	protected GameObject Projectile;
	protected float WindUpTime;
	protected float AttackRate;

	public abstract void Shoot();
}
