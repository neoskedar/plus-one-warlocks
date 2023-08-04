using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MenuController : MonoBehaviour
{
    public GameObject highScore;
    public TextMeshProUGUI highScoreText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.HasKey("Highscore"))
        {
            highScore.SetActive(true);
            highScoreText.text = PlayerPrefs.GetInt("Highscore") + " meters!";

        }
    }
}
