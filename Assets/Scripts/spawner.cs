using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    public GameObject[] obstacle;
    public float smallMin = .25f , smallMax = .75f, largeMin = 1.0f, largeMax = 1.5f;
    int randomObstacle;
    float spawnDelay = 1f;
    // Start is called before the first frame update
    void Start()
    {
            StartCoroutine("Spawn");
            //InvokeRepeating("ObjectSpawner", 1, Random.Range(.25f, 1.5f));
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator Spawn()
    {
        Debug.Log(spawnDelay);
        yield return new WaitForSeconds(spawnDelay);
        randomObstacle = Random.Range(0, obstacle.Length);
        Instantiate(obstacle[randomObstacle], transform.position, Quaternion.identity);
        if (randomObstacle == 0)
        {
            spawnDelay = Random.Range(largeMin, largeMax);
        } else {
            spawnDelay = Random.Range(smallMin, smallMax);
        }
        StartCoroutine("Spawn");
    }

}
