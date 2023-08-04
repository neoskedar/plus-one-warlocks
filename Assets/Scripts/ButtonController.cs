using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    public Sprite OffSprite;
    public Sprite OnSprite;
    public SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseOver()
{
    Debug.Log("Mouse is over GameObject.");
    spriteRenderer.sprite = OnSprite;
}

void OnMouseExit()
{
    spriteRenderer.sprite = OffSprite;
}

    void OnMouseDown()
    {
        // Destroy the gameObject after clicking on it
        Debug.Log("Clicked on the GameObject.");
        SceneManager.LoadScene("Main");
    }
} 