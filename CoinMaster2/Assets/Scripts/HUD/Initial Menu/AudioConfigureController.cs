using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioConfigureController : MonoBehaviour
{
    public Slider mainAudio;
    public Slider musicAudio;
    public Slider effectsAudio;
    public Slider ambience;

    

    //Fmod 
    public FMOD.Studio.Bus musicBus;
    public FMOD.Studio.Bus effectsBus;
    public FMOD.Studio.Bus ambienceBus;
    public FMOD.Studio.Bus bus;


    private void Start()
    {
        FMODUnity.RuntimeManager.StudioSystem.getBus("bus:/Master", out bus);
        FMODUnity.RuntimeManager.StudioSystem.getBus("bus:/Master/Music", out musicBus);
        FMODUnity.RuntimeManager.StudioSystem.getBus("bus:/Master/FX", out effectsBus);
        FMODUnity.RuntimeManager.StudioSystem.getBus("bus:/Master/Ambience", out ambienceBus);
        mainAudio.value = ConfigureManager.Instance.MainVolume;
        musicAudio.value = ConfigureManager.Instance.MusicVolume;
        effectsAudio.value = ConfigureManager.Instance.EffectsVolume;
        ambience.value = ConfigureManager.Instance.AmbienceVolume;

    }
   
    public void SetMainAudio(float value)
    {
        float linearValue = Mathf.Pow(10, value / 20);
        bus.setVolume(linearValue);
        ConfigureManager.Instance.MainVolume = value;
        ConfigureManager.Instance.SaveConfigurations();
    }
    public void SetMusicAudio(float value)
    {
        float linearValue = Mathf.Pow(10, value / 20);
        musicBus.setVolume(linearValue);
        ConfigureManager.Instance.MusicVolume = value;
        ConfigureManager.Instance.SaveConfigurations();
    }
    public void SetEffectsAudio(float value)
    {
        float linearValue = Mathf.Pow(10, value / 20);
        effectsBus.setVolume(linearValue);
        ConfigureManager.Instance.EffectsVolume = value;
        ConfigureManager.Instance.SaveConfigurations();
    }
    public void SetAmbienceAudio(float value)
    {
        float linearValue = Mathf.Pow(10, value / 20);
        ambienceBus.setVolume(linearValue);
        ConfigureManager.Instance.AmbienceVolume = value;
        ConfigureManager.Instance.SaveConfigurations();
    }

}

