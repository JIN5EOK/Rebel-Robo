using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundOption : MonoBehaviour
{
    public AudioMixer audioMixer;

    public Slider BgmSlider;
    public Slider SfxSlider;

    private const string BgmVolumeKey = "BgmVolume";
    private float savedBgmVolume = 1f; // ±âº» º¼·ý °ª

    private const string SfxVolumeKey = "SfxVolume";
    private float savedSfxVolume = 1f;
    private void Awake()
    {
        if (PlayerPrefs.HasKey(BgmVolumeKey))
        {
            savedBgmVolume = PlayerPrefs.GetFloat(BgmVolumeKey);
        }
        if (PlayerPrefs.HasKey(SfxVolumeKey))
        {
            savedSfxVolume = PlayerPrefs.GetFloat(SfxVolumeKey);
        }
    }
    private void Start()
    {
        
        BgmSlider.value = savedBgmVolume;
        SfxSlider.value = savedSfxVolume;
    }
    
    public void SetBgmVolume()
    {
        audioMixer.SetFloat("BGM", Mathf.Log10(BgmSlider.value) * 20);
        savedBgmVolume = BgmSlider.value;
        PlayerPrefs.SetFloat(BgmVolumeKey, savedBgmVolume);
    }
    public void SetSfxVolume()
    {
        audioMixer.SetFloat("SFX", Mathf.Log10(SfxSlider.value) * 20);
        savedSfxVolume = SfxSlider.value;
        PlayerPrefs.SetFloat(SfxVolumeKey, savedSfxVolume);
    }
}
