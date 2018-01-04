using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Weapons/Auto Weapon")]
public class AutoWeapon : Weapon {
    public override bool CheckFireKey() {
        return Input.GetKey(KeyCode.X); // TODO Input manager or smth
    }

    public override void SpawnShots(Transform[] firePoints) {
        for (int i = 0; i < firePoints.Length; i++) {
            for (int j = 0; j < bulletsPerAttack; j++) {
                var point = firePoints[i];
                Instantiate(
                    bullet,
                    point.position,
                    Quaternion.Euler(0.0f, 0.0f, Random.Range(point.eulerAngles.z - spread, point.eulerAngles.z + spread))
                );
            }
        }
    }
}
