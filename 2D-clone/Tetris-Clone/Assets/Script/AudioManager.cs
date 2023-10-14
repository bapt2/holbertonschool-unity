using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public AudioClip[] playList;
    public AudioSource audioSource;

    public AudioMixerGroup soudEffectMixer;

    static AudioManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("there is more than one instance of AudioManager in this scene");
            return;
        }
        instance = this;
    }

    public static AudioManager GetInstance()
    {
        return instance;
    }

    void Start()
    {
        audioSource.clip = playList[0];
        audioSource.Play();
    }

    public AudioSource PlayClipAt(AudioClip clip, Vector3 pos)
    {
        GameObject tempGO = new GameObject("TempAudio");
        tempGO.transform.position = pos;
        AudioSource audioSources = tempGO.AddComponent<AudioSource>();
        audioSources.clip = clip;
        audioSources.outputAudioMixerGroup = soudEffectMixer;
        audioSources.Play();
        Destroy(tempGO, clip.length);
        return audioSources;
    }
}
