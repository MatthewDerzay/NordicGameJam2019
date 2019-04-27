using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverUI : MonoBehaviour
{

    public Text text;

    void Start()
    {
        int deaths = GameManager.instance.GetDeaths();

        if(deaths == 1)
        {
            text.text = "You Died " + deaths.ToString() + " Time";
        } else {
            text.text = "You Died " + deaths.ToString() + " Times";
        }
        
        GameManager.instance.ResetDeaths();
    }
}
