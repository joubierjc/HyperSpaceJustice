using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SpawnType {
    Continue,
    Wave
}

public class Spawner : MonoBehaviour {

    public SpawnType spawnType;
    public List<GameObject> gameObjects;

    public Vector3 spawnValues;

    public float startWait;
    public float spawnWait;
    public float waveWait;

    public int hazardCount;

    private void Start() {
        switch (spawnType) {
            case SpawnType.Continue:
                StartCoroutine(SpawnContinue());
                break;
            case SpawnType.Wave:
                StartCoroutine(SpawnWaves());
                break;
            default:
                break;
        }
    }

    IEnumerator SpawnContinue() {
        yield return new WaitForSeconds(startWait);
        while (true) {
            Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
            Quaternion spawnRotation = Quaternion.identity;
            Instantiate(
                gameObjects[Random.Range(0, gameObjects.Count)],
                spawnPosition,
                spawnRotation
            );
            yield return new WaitForSeconds(spawnWait);
        }
    }

    IEnumerator SpawnWaves() {
        yield return new WaitForSeconds(startWait);
        while (true) {
            for (int i = 0; i < hazardCount; i++) {
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(
                    gameObjects[Random.Range(0, gameObjects.Count)],
                    spawnPosition,
                    spawnRotation
                );
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);
        }
    }
}
