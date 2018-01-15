using UnityEngine;

[CreateAssetMenu(menuName = "Weapons/New Auto Weapon")]
public class AutoWeapon : Weapon {
    public override bool CheckFireKey() {
        return Input.GetKey(KeyCode.X); // TODO Input manager or smth
    }

    public override void SpawnShots(Transform[] firePoints, float damage, bool isFromPlayer = false) {
        for (int i = 0; i < firePoints.Length; i++) {
            for (int j = 0; j < bulletsPerAttack; j++) {
                var point = firePoints[i];
                var b = Instantiate(
                    bullet,
                    point.position,
                    Quaternion.Euler(point.eulerAngles.x, point.eulerAngles.y, Random.Range(point.eulerAngles.z - spread, point.eulerAngles.z + spread))
                );
                var controller = b.GetComponent<BulletController>();
                controller.isFromPlayer = isFromPlayer;
                controller.damage += damage;
            }
        }
    }
}
