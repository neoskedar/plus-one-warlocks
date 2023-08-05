using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossManager : MonoBehaviour
{
    
    uiController uiController;
    public GameObject possumBoss;
    public GameObject hazardSpawner;


    private void Awake()
    {
        uiController = GameObject.Find("Canvas").GetComponent<uiController>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(uiController.distance >= 50)
        {
            possumBoss.SetActive(true);
            hazardSpawner.SetActive(false);

        }
    }
}
