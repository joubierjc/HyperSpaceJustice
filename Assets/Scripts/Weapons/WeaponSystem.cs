using UnityEngine;

public class WeaponSystem : MonoBehaviour {
    public Weapon weapon;
    public Transform[] firePoints;

    private float nextFire;
    private StatsHolder stats;

    private void Start() {
        nextFire = 0f;
        stats = GetComponent<StatsHolder>();
    }

    private void Update() {
        nextFire += Time.deltaTime;
    }

    public void Fire() {
        // TODO: modify spawnshots to implements bonus damage or spread --> Later
        weapon.SpawnShots(firePoints, stats.damage, stats.isPlayer);
    }

    public bool CanFire() {
        if (weapon.CheckFireKey() && (nextFire > weapon.Interval())) {
            nextFire = 0f;
            return true;
        }
        return false;
    }
}
