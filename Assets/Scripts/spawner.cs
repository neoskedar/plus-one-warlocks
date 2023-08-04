using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    public GameObject[] obstacle;
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

    public void ObjectSpawner()
    {
        Instantiate(obstacle[Random.Range(0, obstacle.Length)], transform.position, Quaternion.identity);
    }

    IEnumerator Spawn()
    {
        Debug.Log(spawnDelay);
        yield return new WaitForSeconds(spawnDelay);
        randomObstacle = Random.Range(0, obstacle.Length);
        Instantiate(obstacle[randomObstacle], transform.position, Quaternion.identity);
        if (randomObstacle == 0)
        {
            spawnDelay = Random.Range(1f, 1.5f);
        } else {
            spawnDelay = Random.Range(.25f, .75f);
        }
        StartCoroutine("Spawn");
    }

}
