using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class VolumeSaveHandler : MonoBehaviour
{
    public static VolumeSaveHandler instance { get; private set; }

    [SerializeField] Slider volumeSliderMaster;
    [SerializeField] TextMeshProUGUI volumeTextMaster;

    [SerializeField] Slider volumeSliderMusic;
    [SerializeField] TextMeshProUGUI volumeTextMusic;

    [SerializeField] Slider volumeSliderFx;
    [SerializeField] TextMeshProUGUI volumeTextFX;

    [SerializeField] Slider volumeSliderAmbience;
    [SerializeField] TextMeshProUGUI volumeTextAmbience;

    [SerializeField] AudioMixer audioMixer;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
    }

    private void Start()
    {
        LoadValues();
        
    }

    public void SetMasterVolume(float sliderValue)
    {
        audioMixer.SetFloat("Master", Mathf.Log10(sliderValue) * 20);
        volumeTextMaster.text = sliderValue.ToString("0.0");
        SaveVolumeMaster();
    }

    public void SetMusicVolume(float sliderValue)
    {
        audioMixer.SetFloat("Music", Mathf.Log10(sliderValue) * 20);
        volumeTextMusic.text = sliderValue.ToString("0.0");
        SaveVolumeMusic();
    }

    public void SetFXVolume(float sliderValue)
    {
        audioMixer.SetFloat("FX", Mathf.Log10(sliderValue) * 20);
        volumeTextFX.text = sliderValue.ToString("0.0");
        SaveVolumeFX();
    }

    public void SetAmbienceVolume(float sliderValue)
    {
        audioMixer.SetFloat("Ambience", Mathf.Log10(sliderValue) * 20);
        volumeTextAmbience.text = sliderValue.ToString("0.0");
        SaveVolumeAmbience();
    }


    public void SaveVolumeMaster()
    {
        float volumeValueMaster = volumeSliderMaster.value;
        PlayerPrefs.SetFloat("Master", volumeValueMaster);

    }
    
    public void SaveVolumeMusic()
    {
        float volumeValueMusic = volumeSliderMusic.value;
        PlayerPrefs.SetFloat("Music", volumeValueMusic);
    }

    public void SaveVolumeFX()
    {
        float volumeValueFX = volumeSliderFx.value;
        PlayerPrefs.SetFloat("FX", volumeValueFX);
    }

    public void SaveVolumeAmbience()
    {
        float volumeValueAmbience = volumeSliderAmbience.value;
        PlayerPrefs.SetFloat("Ambience", volumeValueAmbience);
    }

    

    private void LoadValues()
    {
        float volumeValueMaster = PlayerPrefs.GetFloat("Master");
        volumeSliderMaster.value = volumeValueMaster;
        audioMixer.SetFloat("Master", volumeValueMaster);

        
        float volumeValueMusic = PlayerPrefs.GetFloat("Music");
        volumeSliderMaster.value = volumeValueMusic;
        audioMixer.SetFloat("Music", volumeValueMusic);

        float volumeValueFX = PlayerPrefs.GetFloat("FX");
        volumeSliderMaster.value = volumeValueFX;
        audioMixer.SetFloat("FX", volumeValueFX);

        float volumeValueAmbience = PlayerPrefs.GetFloat("Ambience");
        volumeSliderMaster.value = volumeValueAmbience;
        audioMixer.SetFloat("Ambience", volumeValueAmbience);
        

    }
}
