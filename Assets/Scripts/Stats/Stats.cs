using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Stats {
    
    [SerializeField]
    private float _health;
    public float health {
        get {
            return _health;
        }
        set {
            _health = value;
            OnHealthChanged(_health);
        }
    }

    public float damage;

    public Action<float> OnHealthChanged = delegate { }; // delegate { } to avoid null check
}
