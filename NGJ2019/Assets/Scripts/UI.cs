using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    private static UI _instance;
    public Text text;

    public static UI instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = GameObject.FindObjectOfType<UI>();
                if(_instance == null)
                {
                    throw new UnityException("Instance of UI not found in scene");
                }
            }
            return _instance;
        }
    }

    private void Awake() {
        _instance = this;
        text.text = "Deaths: " + GameManager.instance.GetDeaths().ToString();
    }

    public void UpdateDeaths(int lives)
    {
        text.text = "Deaths: " + lives.ToString();
    }
}
