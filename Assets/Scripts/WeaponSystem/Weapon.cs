using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//The base item class. All items should derive from this.

public abstract class Weapon : ScriptableObject {
    public string attachedTo;

    public int bulletCount;
    public float bulletPerSecond;
    [Range(0, 180)]
    public float spread;
    
    public virtual void Fire(GameObject bullet, Transform shotTransform, bool isFirePressed, Action callback) {
        // Maybe a use later on.
    }

    public float GetFireRate() {
        // A changer pour l'init dès qu'on change l'arme à la place de l'appeler à chaque fois.
        // On est pas sensé changer le fireRate sans changer d'arme.
        return (1 / bulletPerSecond);
    }

    protected void SetBulletInfo(GameObject bullet) {
        var shot = bullet.GetComponent<Shot>();
        shot.firedBy = attachedTo;
    }
}
