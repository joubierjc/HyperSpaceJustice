using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Waves/New Wave")]
public class Wave : ScriptableObject {
    public new string name;
    public bool bossWave;
    public int numberOfEnnemies;
    public float waitBetweenSpawn;
    public GameObject[] enemies;
}
