using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossManager : MonoBehaviour
{
    
    uiController uiController;
    spawner spawner;
    public GameObject possumBoss;
    public GameObject hazardSpawner;
    private SoundManager soundManager;
    private bool runningSpawner = true;
    private void Awake()
    {
        uiController = GameObject.Find("Canvas").GetComponent<uiController>();
        spawner = GameObject.Find("HazardSpawner").GetComponent<spawner>();
        soundManager = FindObjectOfType<SoundManager>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //turn off hazard spawner
        if (uiController.distance == 200)
        {
            spawner.activeBoss = true;
            runningSpawner = false;
        }
        //turn on hazard spawner
        if (uiController.distance == 620)
        {
            spawner.activeBoss = false;
            if (runningSpawner == false)
            {
                spawner.StartSpawner();
                runningSpawner = true;
            }
        }
        //activate boss n music
        if (uiController.distance == 250)
        {
            possumBoss.SetActive(true);
            if (soundManager.bossMusic != null)
                soundManager.ChangeBGM(soundManager.bossMusic);
        }
        //deactivate boss n music
        if (uiController.distance == 600)
        {
            possumBoss.SetActive(false);
            if(soundManager.mainBackgroundMusic != null)
                soundManager.ChangeBGM(soundManager.mainBackgroundMusic);
        }
    }
}
