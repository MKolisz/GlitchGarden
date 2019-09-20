using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour
{

    bool spawn = true;
    [SerializeField] float minSpawnDelay = 1f;
    [SerializeField] float maxSpawnDelay = 5f;
    [SerializeField] Attacker[] attackerPrefabs;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        while (spawn)
        {
            yield return new WaitForSeconds(Random.Range(minSpawnDelay, maxSpawnDelay));
            SpawnAttacker();
        }
    }

    public void StopSpawning()
    {
        spawn = false;
    }

    private void SpawnAttacker()
    {
        int spawnIndex = Random.Range(0, attackerPrefabs.Length);
        Spawn(spawnIndex);
    }

    private void Spawn(int spawnIndex)
    {
        Attacker newAttacker = Instantiate(attackerPrefabs[spawnIndex], transform.position, transform.rotation) as Attacker;
        newAttacker.transform.parent = transform;
    }
}
