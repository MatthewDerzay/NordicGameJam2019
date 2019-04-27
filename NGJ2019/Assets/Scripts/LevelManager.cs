using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private PlayerSpawner spawner;
    public string nextScene;

    private static LevelManager _instance;

    public static LevelManager instance
        {
            get
            {
                if(_instance == null)
                {
                    _instance = GameObject.FindObjectOfType<LevelManager>();
                    if(_instance == null)
                    {
                        throw new UnityException("Instance of LevelManager not found in scene");
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
    }

    private void Start() {
        spawner = GameObject.Find("PlayerSpawn").GetComponent<PlayerSpawner>();
        spawner.Spawn();
    }

    public void NextScene()
    {
        SceneManager.LoadScene(nextScene);
    }
}
