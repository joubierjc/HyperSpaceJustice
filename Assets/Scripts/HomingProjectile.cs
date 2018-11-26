using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody))]
public class HomingProjectile : Projectile {

	[SerializeField]
	private EntityType searchFilter;
	[SerializeField]
	private float searchRadius = 5f;

	private Transform target;


}
