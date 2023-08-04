using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverController : MonoBehaviour
{
    player player;
    public TextMeshProUGUI scoreText;
    public GameObject highscoreText;

    private void Awake()
    {
        player = GameObject.Find("Player").GetComponent<player>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int distance = Mathf.FloorToInt(player.distance);
        scoreText.text = distance + " meters!";
        if (distance > PlayerPrefs.GetInt("Highscore"))
        {
            highscoreText.SetActive(true);
            PlayerPrefs.SetInt("Highscore", distance);
        } 
    }

    public void NewGame()
    {
        SceneManager.LoadScene("Main");

    }

    public void QuitGame()
    {
        SceneManager.LoadScene("Title");
    }
}
