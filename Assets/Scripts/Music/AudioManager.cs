using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    public AudioClip bgmSpace;
    public AudioClip click;
    List<AudioSource> audios = new List<AudioSource>();
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }  
        for (int i = 0; i < 3; i++)
        {
            var audio = this.gameObject.AddComponent<AudioSource>();
            audios.Add(audio);
        }
    }
    void Start()
    {
        
    }
    public void Play(int index, string name, bool isLoop)
    {
        var clip = GetAudioClip(name);
        if (clip != null)
        {
            var audio = audios[index];
            audio.clip = clip;
            audio.loop = isLoop;
            audio.Play();
        }
        
    }
    AudioClip GetAudioClip(string name)
    {
        switch (name)
        {
            case "bgmSpace":
                return bgmSpace;
            case "click":
                return click;
        }
        return null;
    }
}
