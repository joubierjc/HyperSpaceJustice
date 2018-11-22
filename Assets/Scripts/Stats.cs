using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour {
	[Header("Health settings")]
	[SerializeField]
	private float baseHealth;
	[SerializeField]
	private float maxHealth;
	[SerializeField]
	private float currentHealth;

	[Header("Energy settings")]
	[SerializeField]
	private float baseEnergy;
	[SerializeField]
	private float maxEnergy;
	[SerializeField]
	private float currentEnergy;

}
