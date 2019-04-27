using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private int deaths = 0;

    private static GameManager _instance;

    public static GameManager instance
        {
            get
            {
                if(_instance == null)
                {
                    _instance = GameObject.FindObjectOfType<GameManager>();
                    if(_instance == null)
                    {
                        throw new UnityException("Instance of GameManager not found in scene");
                    }
                }
                return _instance;
            }
        }

    private void Awake() {
        if(_instance == null)
        {
            _instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
        UI.instance.UpdateDeaths(deaths);
    }

    public void AddDeath()
    {
        deaths++;
        UI.instance.UpdateDeaths(deaths);
    }

    public void ResetDeaths()
    {
        deaths = 0;
    }

    public int GetDeaths()
    {
        return deaths;
    }
}
