using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//The base item class. All items should derive from this.

[CreateAssetMenu(fileName = "New Weapon", menuName = "WeaponSystem/EmptyWeapon", order = 1)]
public class Weapon : ScriptableObject {
    public int bulletCount;
    public float bulletPerSecond;
    [Range(0, 180)]
    public float spread;
    
    public virtual void Fire() {
        // Maybe a use later on.
    }

    public float GetFireRate() {
        // A changer pour l'init dès qu'on change l'arme à la place de l'appeler à chaque fois.
        // On est pas sensé changer le fireRate sans changer d'arme.
        return (1 / bulletPerSecond);
    }
}
