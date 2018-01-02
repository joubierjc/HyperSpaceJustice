using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSystem : MonoBehaviour {
    public Weapon weapon;
    public Transform[] firePoints;

    private float nextFire;

    private void Start() {
        nextFire = 0f;
    }

    private void Update() {
        nextFire += Time.deltaTime;
    }

    public void Fire() {
        weapon.SpawnShots(firePoints);
    }

    public bool CanFire() {
        if (weapon.CheckFireKey() && (nextFire > weapon.Interval())) {
            nextFire = 0f;
            return true;
        }
        return false;
    }
}
