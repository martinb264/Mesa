using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Audio;

public class OptionsScript : MonoBehaviour
{
    //Made with the help of https://www.youtube.com/watch?v=76WOa6IU_s8 
    [SerializeField]
    private Toggle fullScreenTog, vSyncTog;

    [SerializeField]
    private List<resItem> resolutions = new List<resItem>();

    [SerializeField]
    private TMP_Text resolutionLabel;

    private int selectedRes;

    [SerializeField]
    private AudioMixer audioMixer;

    [SerializeField]
    private TMP_Text masterLabel, musicLabel, sfxLabel;
    [SerializeField]
    private Slider masterSlider,musicSlider,sfxSlider;
    // Start is called before the first frame update
    void Start()
    {
        fullScreenTog.isOn = Screen.fullScreen;

        if(QualitySettings.vSyncCount == 0)
        {
            vSyncTog.isOn = false;
        }else
        {
            vSyncTog.isOn = true;
        }

        bool foundRes = false;

        for(int i = 0; i < resolutions.Count; i++)
        {
            if(Screen.width == resolutions[i].horizontal && Screen.width == resolutions[i].vertical)
            {
                foundRes = true;

                selectedRes = i;

                updateResLabel();
            }
        }
        if(!foundRes)
        {
            resItem newRes = new resItem();
            newRes.horizontal = Screen.width;
            newRes.vertical = Screen.height;

            resolutions.Add(newRes);
        }

        float vol = 0f;
        audioMixer.GetFloat("MasterVol", out vol);
        masterSlider.value = vol;
        audioMixer.GetFloat("MusicVol", out vol);
        musicSlider.value = vol;
        audioMixer.GetFloat("SFXVol", out vol);
        sfxSlider.value = vol;

        masterLabel.text = Mathf.RoundToInt(masterSlider.value + 80).ToString();
        musicLabel.text = Mathf.RoundToInt(musicSlider.value + 80).ToString();
        sfxLabel.text = Mathf.RoundToInt(sfxSlider.value + 80).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void resLeft()
    {
        selectedRes--;
        if(selectedRes < 0)
        {
            selectedRes = 0;
        }
        updateResLabel();
    }

    public void resRight()
    {
        selectedRes++;
        if(selectedRes > resolutions.Count - 1)
        {
            selectedRes = resolutions.Count - 1;
        }
        updateResLabel();
    }
    public void updateResLabel()
    {
        resolutionLabel.text = resolutions[selectedRes].horizontal.ToString() + " x " + resolutions[selectedRes].vertical.ToString();
    }
    public void ApplyGraphics()
    {
        //Screen.fullScreen = fullScreenTog.isOn;
        if(vSyncTog.isOn)
        {
            QualitySettings.vSyncCount = 1;
        } else
        {
            QualitySettings.vSyncCount = 0;
        }

        Screen.SetResolution(resolutions[selectedRes].horizontal, resolutions[selectedRes].vertical, fullScreenTog.isOn);
    }
    public void setMasterVol()
    {
        masterLabel.text = Mathf.RoundToInt(masterSlider.value+80).ToString();

        audioMixer.SetFloat("MasterVol",masterSlider.value);

        PlayerPrefs.SetFloat("MasterVol", masterSlider.value);
    }
    public void setMusicVol()
    {
        musicLabel.text = Mathf.RoundToInt(musicSlider.value + 80).ToString();

        audioMixer.SetFloat("MusicVol", musicSlider.value);

        PlayerPrefs.SetFloat("MusicVol", musicSlider.value);
    }
    public void setSFXVol()
    {
        sfxLabel.text = Mathf.RoundToInt(sfxSlider.value + 80).ToString();

        audioMixer.SetFloat("SFXVol", sfxSlider.value);

        PlayerPrefs.SetFloat("SFXVol", sfxSlider.value);
    }
}

[System.Serializable]
public class resItem
{
    public int horizontal, vertical;
}
