using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    public GameObject[] obstacle;
    public float smallMin = .25f , smallMax = .75f, largeMin = 1.0f, largeMax = 1.5f;
    int randomObstacle;
    float spawnDelay = 1f;
    public bool activeBoss = false;

    // Start is called before the first frame update
    void Start()
    {
            StartCoroutine("Spawn");
            Debug.Log(obstacle.Length);
            //InvokeRepeating("ObjectSpawner", 1, Random.Range(.25f, 1.5f));
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartSpawner()
    {
        StartCoroutine("Spawn");
    }

    IEnumerator Spawn()
    {
        while (activeBoss == false)
        {
            yield return new WaitForSeconds(spawnDelay);
            randomObstacle = Random.Range(0, obstacle.Length);
            Debug.Log("Hazard Spawner is called!");
            Instantiate(obstacle[randomObstacle], transform.position, Quaternion.identity);
            if (randomObstacle < 2)
            {
                spawnDelay = Random.Range(largeMin, largeMax);
            }
            else
            {
                spawnDelay = Random.Range(smallMin, smallMax);
            }
        }
        //StartCoroutine("Spawn");
    }

}
