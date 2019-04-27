using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSound : MonoBehaviour
{

    public AudioClip[] oofs;
    private static PlayerSound _instance;
    private AudioSource source;

    public static PlayerSound instance
        {
            get
            {
                if(_instance == null)
                {
                    _instance = GameObject.FindObjectOfType<PlayerSound>();
                    if(_instance == null)
                    {
                        throw new UnityException("Instance of PlayerSound not found in scene");
                    }
                }
                return _instance;
            }
        }

    private void Awake() {
        _instance = this;

        source = GetComponent<AudioSource>();
    }

    public void PlayOof()
    {
        int random = Random.Range(0, oofs.Length);
        source.PlayOneShot(oofs[random]);
    }
}
