using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverUI : MonoBehaviour
{

    public Text text;
    public Image image;
    public Sprite[] images;

    void Start()
    {
        int deaths = GameManager.instance.GetDeaths();

        if(deaths == 1)
        {
            text.text = "You Died " + deaths.ToString() + " Time";
        } else {
            text.text = "You Died " + deaths.ToString() + " Times";
        }

        if(deaths > 20)
        {
            image.sprite = images[0];
            text.color = new Color(255, 255, 255, 100);
        } else
        {
            image.sprite = images[1];
        }
        
        GameManager.instance.ResetDeaths();
    }
}
