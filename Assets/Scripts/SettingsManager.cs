using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using System.Linq;

public class SettingsManager : MonoBehaviour
{

    public GameObject mainmenu;
    public GameObject settings;
    public GameObject credits;

    public AudioMixer soundMixer;
    public AudioMixer musicMixer;

    public Dropdown resDrop;
    private Resolution[] resolutions;

    void Start()
    {

        //--------------------------------------------RESOLUTIONS--------------------------------------------------------

        resolutions = Screen.resolutions.Select(resolution => new Resolution { width = resolution.width, height = resolution.height }).Distinct().ToArray();
        resDrop.ClearOptions();

        List<string> options = new List<string>();
        int currentResIndex = 0;

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.width && resolutions[i].height == Screen.height)
            {
                currentResIndex = i;
            }
        }

        resDrop.AddOptions(options);
        resDrop.value = currentResIndex;
        resDrop.RefreshShownValue();

        //--------------------------------------------RESOLUTIONS--------------------------------------------------------
    }

    public void SetSound(float soundVolume) //Volume level
	{
        soundMixer.SetFloat("Sound", soundVolume);
	}

    public void SetMusic(float musicVolume) //Volume level
    {
        musicMixer.SetFloat("Music", musicVolume);
    }

    public void SetResolution(int resIndex) //Resolution settings
	{
        Resolution resolution = resolutions[resIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
	}

    public void SetQuality(int qualityIndex)
	{
        QualitySettings.SetQualityLevel(qualityIndex);
	}

    public void OpenSettings() //Open settings menu
	{
        mainmenu.SetActive(false);
        settings.SetActive(true);
        credits.SetActive(false);
	}

    public void SaveSettings() //Close and save settings
    {
        mainmenu.SetActive(true);
        settings.SetActive(false);
        credits.SetActive(false);
    }

    public void OpenCredits() //Open credits
	{
        mainmenu.SetActive(false);
        settings.SetActive(false);
        credits.SetActive(true);
    }

    public void CloseCredits() //CLose credits
    {
        mainmenu.SetActive(true);
        settings.SetActive(false);
        credits.SetActive(false);
    }
}
