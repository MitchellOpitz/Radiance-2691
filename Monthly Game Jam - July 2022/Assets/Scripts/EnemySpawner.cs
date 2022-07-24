using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;
    public float spawnInterval = 3f;

    public float maxX = 5f;
    public float maxY = 5f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnEnemy(spawnInterval, enemy));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator spawnEnemy (float interval, GameObject enemy)
    {
        yield return new WaitForSeconds(interval);
        if(Random.value > .5)
        {
            GameObject newEnemy = Instantiate(enemy, new Vector3(
                Random.Range(-maxX, maxX),
                Random.value > .5 ? maxY : -maxY,
                0), Quaternion.identity);
        } else
        {
            GameObject newEnemy = Instantiate(enemy, new Vector3(
                Random.value > .5 ? maxX : -maxX,
                Random.Range(-maxY, maxY),
                0), Quaternion.identity);
        }
        StartCoroutine(spawnEnemy(interval, enemy));
    }
}
