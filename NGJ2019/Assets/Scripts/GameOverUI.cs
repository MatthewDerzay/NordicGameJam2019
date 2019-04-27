using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverUI : MonoBehaviour
{

    public Text text;

    void Start()
    {
        text.text = "You Died " + GameManager.instance.GetDeaths() + " Times";
        GameManager.instance.ResetDeaths();
    }
}
