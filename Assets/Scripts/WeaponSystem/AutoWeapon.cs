using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Auto Weapon", menuName = "WeaponSystem/AutoWeapon", order = 1)]
public class AutoWeapon : Weapon {
    public override void Fire() {
        if (Input.GetKey(Player.instance.shotKey)) {
            Player.instance.ResetNextFire();
            for (var i = 0; i < bulletCount; i++) {
                Instantiate(Player.instance.bullet, Player.instance.shotTransform.position, Quaternion.Euler(0.0f, Random.Range(-spread, spread), 0.0f));
            }
        }
    }
}
