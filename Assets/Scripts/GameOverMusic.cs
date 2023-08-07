using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverMusic : MonoBehaviour
{
    
    private SoundManager soundManager;
    // Start is called before the first frame update
    void Start()
    {
        soundManager = FindObjectOfType<SoundManager>();
        if(soundManager.gameOverMusic != null)
            soundManager.ChangeBGM(soundManager.gameOverMusic);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
