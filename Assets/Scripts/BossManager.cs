using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossManager : MonoBehaviour
{
    
    uiController uiController;
    spawner spawner;
    public GameObject possumBoss;
    public GameObject hazardSpawner;


    private void Awake()
    {
        uiController = GameObject.Find("Canvas").GetComponent<uiController>();
        spawner = GameObject.Find("HazardSpawner").GetComponent<spawner>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (uiController.distance >= 100 && uiController.distance <= 110)
            spawner.StopCoroutine("Spawn");

        if (uiController.distance >= 250 && uiController.distance <= 260)
            spawner.StartCoroutine("Spawn");

        if (uiController.distance >= 150 && uiController.distance <= 160)
            possumBoss.SetActive(true);

        if (uiController.distance >= 200 && uiController.distance <= 210)
            possumBoss.SetActive(false);
    }
}
