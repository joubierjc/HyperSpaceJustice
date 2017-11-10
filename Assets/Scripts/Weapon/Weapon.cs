using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Inventory/Weapon", order = 1)]
public class Weapon : ScriptableObject {
    public ShootingMode mode;
    public GameObject shot;
    public int projectileCount;
    public float projectileSpeed;
    public float projectileDamage;
    public float fireRate;
    [Range(0, 180)]
    public float spread;
}
