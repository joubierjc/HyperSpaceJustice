using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : ScriptableObject {
	public GameObject Projectile;
	public float Damage;
	public float CoolDown;
	public float AccuracyLoss;
	public LayerMask ProjectileLayerRef;

	public abstract void Init(GameObject obj);
	public abstract void Trigger();
}
