using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ShootingMode {
    Single,
    Auto,
    Burst
}

public class WeaponManager : MonoBehaviour {
    public Weapon weapon;

    private PlayerController player;
    private float nextFire;
    private float fireRate;
    private float spread;

    private void Start() {
        player = gameObject.GetComponentInParent<PlayerController>();
        SetWeapon(weapon);
    }

    public void SetWeapon(Weapon w) {
        fireRate = 1 / (player.attackSpeed + weapon.fireRate);
        nextFire = fireRate;
        spread = player.spread + weapon.spread;
    }

    private void Update() {
        nextFire += Time.deltaTime;
        FireWeapon();
    }

    public void FireWeapon() {
        if (nextFire > fireRate) {
            switch (weapon.mode) {
                case ShootingMode.Single:
                    FireSingle();
                    break;
                case ShootingMode.Auto:
                    FireAuto();
                    break;
                case ShootingMode.Burst:
                    FireBurst();
                    break;
                default:
                    break;
            }
        }
    }

    private void FireSingle() {

    }

    private void FireAuto() {
        if (Input.GetKey(player.shotKey)) {
            nextFire = 0;
            for (var i = 0; i < weapon.projectileCount; i++) {
                Instantiate(weapon.shot, transform.position, Quaternion.Euler(0.0f, Random.Range(-spread, spread), 0.0f));
            }
        }
    }

    private void FireBurst() {

    }

}
