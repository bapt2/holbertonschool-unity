using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;


public class AudioSettings : MonoBehaviour
{
    public AudioMixer audioMixeur;
    public Slider musicSlider;
    public Slider soundSlider;

    void Start()
    {
        audioMixeur.GetFloat("Music", out float musicValueForSlider);
        musicSlider.value = musicValueForSlider;

        audioMixeur.GetFloat("Sound", out float soundValueForSlider);
        soundSlider.value = musicValueForSlider;
    }

    public void SetVolume(float volume)
    {
        audioMixeur.SetFloat("Music", volume);
    }

    public void SetSoundVolume(float volume)
    {
        audioMixeur.SetFloat("Sound", volume);
    }
}
