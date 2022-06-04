using UnityEngine;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;

    public void SetVolumeMusic(float volume) {
        audioMixer.SetFloat("music", volume);
    }

    public void SetVolumeSound(float volume) {
        audioMixer.SetFloat("sound", volume);
    }
}
