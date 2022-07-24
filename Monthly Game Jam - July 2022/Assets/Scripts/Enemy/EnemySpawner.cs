using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    // Public variaables
    public GameObject enemy;
    public float spawnInterval = 3f;
    public float maxX = 5f;
    public float maxY = 5f;

    void Start()
    {
        StartCoroutine(spawnEnemy(spawnInterval, enemy));
    }

    private IEnumerator spawnEnemy (float interval, GameObject enemy)
    {
        yield return new WaitForSeconds(interval);

        // Force either X or Y will always be at their min/max value.
        // Ensures enemies will always spawn out of the gameplay view.
        if(Random.value > .5)
        {
            GameObject newEnemy = Instantiate(enemy, new Vector3(
                Random.Range(-maxX, maxX),  // X remains random
                Random.value > .5 ? maxY : -maxY,  // Random top or bottom
                0), Quaternion.identity);
        } else
        {
            GameObject newEnemy = Instantiate(enemy, new Vector3(
                Random.value > .5 ? maxX : -maxX,  // Random left or right
                Random.Range(-maxY, maxY),  // Y remains random
                0), Quaternion.identity);
        }

        StartCoroutine(spawnEnemy(interval, enemy));
    }
}
