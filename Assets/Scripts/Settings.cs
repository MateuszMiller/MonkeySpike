using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Settings : MonoBehaviour
{
    public AudioMixer audioMixer;

    public TMP_Dropdown resolutionDropdown;

    Resolution[] resolutions;


    public GameObject player;

    public GameObject optionsMenu;

    private void Start()
    {
        resolutions = Screen.resolutions;

        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        int currentResolutionIndex = 0;

        for(int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);

    }

    public void SetVolume (float volume)
    {

        audioMixer.SetFloat("volume",volume);

    }
    public void SetFullscreen(bool fullscreen)
    {

        Screen.fullScreen = fullscreen;
    }

    

    public void ActivateShop()
    {
        optionsMenu.SetActive(false);
        if (gameObject.activeSelf)
        {
            DeactivateSettings();
            return;
        }
        gameObject.SetActive(true);
        if (player != null)
        {
            player.SetActive(false);
        }

    }

    public void DeactivateSettings()
    {
        gameObject.SetActive(false);
        optionsMenu.SetActive(true);
        player.SetActive(true);
        BlinkingText.instance._StartCoroutine();

    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
