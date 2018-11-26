using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuntimeEntity : MonoBehaviour {

	[SerializeField]
	private EntityType filter;

	private void OnEnable() {
		EntityTracker.Register(filter, gameObject);
	}

	private void OnDisable() {
		EntityTracker.Unregister(filter, gameObject);
	}
}
