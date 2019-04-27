using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private PlayerSpawner spawner;
    public string nextScene;
    private int score;

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
        if(_instance != null)
        {
            Destroy(_instance.gameObject);
        }
        _instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    private void Start() {
        spawner = GameObject.Find("PlayerSpawn").GetComponent<PlayerSpawner>();
        spawner.Spawn();
    }

    public void NextScene()
    {
        SceneManager.LoadScene(nextScene);
    }

    public void SetLevelScore()
    {
        //SceneManager.sceneLoaded;
    }

    public void ReduceScore()
    {
        score--;
    }
}
