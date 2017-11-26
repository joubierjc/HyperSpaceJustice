using System;
using UnityEngine;

[CreateAssetMenu(fileName = "New Auto Weapon", menuName = "WeaponSystem/AutoWeapon", order = 1)]
public class AutoWeapon : Weapon {
    public override void Fire(GameObject bullet, Transform shotTransform, bool isFirePressed, Action callback) {
        if (isFirePressed) {
            for (var i = 0; i < bulletCount; i++) {
                var go = Instantiate(bullet, shotTransform.position, Quaternion.Euler(0.0f, UnityEngine.Random.Range(-spread, spread), 0.0f));
                SetBulletInfo(go);
            }
            callback();
        }
    }
}
