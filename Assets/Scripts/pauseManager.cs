using UnityEngine;
using FMODUnity;
using UnityEngine.UI;

public class pauseManager : MonoBehaviour
{
    public GameObject pauseUI;
    public float MusicVolume;
    public float AmbientVolume;
    public float MainVolume;
    public float SFXVolume;
    private string path;
    public string vcaName;
    public FMOD.Studio.VCA MainVCA;
    public FMOD.Studio.VCA MusicVCA;
    public FMOD.Studio.VCA AMBVCA;
    public FMOD.Studio.VCA SFXVCA;
    public Slider MainSlider;
    public Slider SFXSlider;
    public Slider AmbientSlider;
    public Slider MusicSlider;

    private void Start()
    {
        path = $"vca:/{vcaName}";
        MainSlider.value = PlayerPrefs.GetFloat("Main");
        MusicSlider.value = PlayerPrefs.GetFloat("Music");
        AmbientSlider.value = PlayerPrefs.GetFloat("Amb");
        SFXSlider.value = PlayerPrefs.GetFloat("SFX");
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            pauseUI.SetActive(!pauseUI.activeInHierarchy);
        }
    }
    public void ChangeMain()
    {
        vcaName = "Main";
        path = $"vca:/{vcaName}";
        MainVolume = MainSlider.value;
        PlayerPrefs.SetFloat("Main", MainVolume);
        MainVCA = FMODUnity.RuntimeManager.GetVCA(path);
        MainVCA.setVolume(MainVolume);
    }

    public void ChangeMusic()
    {
        vcaName = "Music";
        path = $"vca:/{vcaName}";
        MusicVolume = MusicSlider.value;
        PlayerPrefs.SetFloat("Music", MusicVolume);
        MusicVCA = FMODUnity.RuntimeManager.GetVCA(path);
        MusicVCA.setVolume(MusicVolume);
    }

    public void ChangeAmbient()
    {
        vcaName = "AMB";
        path = $"vca:/{vcaName}";
        AmbientVolume = AmbientSlider.value;
        PlayerPrefs.SetFloat("Amb", AmbientVolume);
        AMBVCA = FMODUnity.RuntimeManager.GetVCA(path);
        AMBVCA.setVolume(AmbientVolume);
    }

    public void ChangeSFX()
    {
        vcaName = "SFX";
        path = $"vca:/{vcaName}";
        SFXVolume = SFXSlider.value;
        PlayerPrefs.SetFloat("SFX", SFXVolume);
        SFXVCA = FMODUnity.RuntimeManager.GetVCA(path);
        SFXVCA.setVolume(SFXVolume);
    }
}
