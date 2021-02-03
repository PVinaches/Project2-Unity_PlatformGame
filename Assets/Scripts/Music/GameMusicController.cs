using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class GameMusicController : MonoBehaviour
{
    // New
    public Slider slider;
    
    // Start is called before the first frame update
    void Start()
    {
        /* SetVolume(VolumeController.MusicVolume); */
        GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("MusicVolume", 0.75f);
        slider.value = PlayerPrefs.GetFloat("MusicVolume", 0.75f);

        GetComponent<AudioSource>().Play();
    }

    // Update is called once per frame
    public void SetVolume(float volume)
    {
        GetComponent<AudioSource>().volume = volume;
        slider.value = volume;

        // VolumeController.MusicVolume = volume;
        /* print(volume); */

        // New
        /* this.SetFloat("MusicVol", Mathf.Log10(volume) * 20); */
        PlayerPrefs.SetFloat("MusicVolume", volume);
    }
}
