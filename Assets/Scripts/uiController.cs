using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class uiController : MonoBehaviour
{
    player player;
    TMP_Text distanceText;

    private void Awake()
    {
        player = GameObject.Find("Player").GetComponent<player>();
        distanceText = GameObject.Find("DistanceText").GetComponent<TextMeshProUGUI>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int distance = Mathf.FloorToInt(player.distance);
        distanceText.text = distance + " m";
    }
}
