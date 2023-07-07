using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    //audio sources
    [SerializeField] private AudioSource gameAudio, UiAudio; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayBoomSound()
    {
        gameAudio.Play();
    }
    
    #region Singleton

    public static AudioManager Instance;

    private void Awake()
    {
        if (Instance != this)
        {
            Destroy(Instance);
        }

        Instance = this;
    }

    #endregion
}
