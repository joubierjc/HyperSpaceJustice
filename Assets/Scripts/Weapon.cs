using UnityEngine;

public abstract class Weapon : ScriptableObject {
    [Range(1, 100)]
    public int attacksPerSecond;
    [Range(1, 10)]
    public int bulletsPerAttack;
    [Range(0, 180)]
    public float spread;
    public GameObject bullet;
    
    public abstract bool CheckFireKey();
    public abstract void SpawnShots(Transform[] firePoints);

    public float Interval() {
        return 1f / attacksPerSecond;
    }
}
