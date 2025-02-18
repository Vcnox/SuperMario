using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public static AudioManager instance;
    private List<AudioSource> _sounds;

    private void Awake()
    {
        if (!instance)
        {

            instance = this;
            DontDestroyOnLoad(gameObject);

        }
        else
        {
            Destroy(gameObject);
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        _sounds = new List<AudioSource>();
    }

    public AudioSource PlayAudio(AudioClip clip, string gameObjectName, bool isLoop = false, float volume = 1.0f)
    {
        GameObject nObject = new GameObject();
        nObject.name = gameObjectName;
        AudioSource audioSourceComponent = nObject.AddComponent<AudioSource>();
        audioSourceComponent.clip = clip;
        audioSourceComponent.loop = isLoop;
        audioSourceComponent.volume = volume;
        _sounds.Add(audioSourceComponent);
        audioSourceComponent.Play();

        return audioSourceComponent;
    }
    
private IEnumerator WaitForAudio(AudioSource source)
    {
        if (source.loop)
        {
            yield return null;
        }
        else
        {
            while(source.isPlaying)
            {
                yield return new WaitForSeconds(0.3f);

            }
            Destroy(source.gameObject);
        }
    }



}

