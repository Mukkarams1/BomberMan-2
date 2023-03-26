using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainmenuManager : MonoBehaviour
{
    public Toggle AudioMute;
    public Toggle FlipControls;
    public Toggle DualFlipControls;
    public GameObject Settingpanel;
    public bool SinglePlayerControlsAreSwitched;
    public bool DualPlayerControlsAreSwitched;
   
    // Start is called before the first frame update
    void Start()
    {
        Settingpanel.SetActive(false);
        bool MusicBool = (PlayerPrefs.GetInt("AudioOn") == 1) ? true : false;
        AudioMute.isOn = MusicBool;

        bool Controlsbool = (PlayerPrefs.GetInt("FlipControls") == 1) ? true : false;
        FlipControls.isOn = Controlsbool;

        bool dualControlsbool = (PlayerPrefs.GetInt("DualFlipControls") == 1) ? true : false;
        DualFlipControls.isOn = dualControlsbool;
    }

    // Update is called once per frame
    void Update()
    {
        volumeToggle();
        AudioCheck();
        Controls();
        ControlsCheck();
        DualControls();
        DualControlsCheck();
    }
    public void OnDualPlayerClicked()
    {
        PlayerPrefs.DeleteKey("Score1");
        PlayerPrefs.DeleteKey("Score2");
        SceneManager.LoadScene(21);
    }
    public void volumeToggle()
    {
        if (AudioMute.isOn == true)
        {
            PlayerPrefs.SetInt("AudioOn", 1);
        }
        else
        {
            PlayerPrefs.SetInt("AudioOn", 0);
        }

    }
    public void Controls()
    {
        if (FlipControls.isOn == true)
        {
            PlayerPrefs.SetInt("FlipControls", 1);
        }
        else
        {
            PlayerPrefs.SetInt("FlipControls", 0);
        }

    }
    public void DualControls()
    {
        if (DualFlipControls.isOn == true)
        {
            PlayerPrefs.SetInt("DualFlipControls", 1);
        }
        else
        {
            PlayerPrefs.SetInt("DualFlipControls", 0);
        }

    }

    public void AudioCheck()
    {
        if (PlayerPrefs.HasKey("AudioOn"))
        {
            if (PlayerPrefs.GetInt("AudioOn") > 0)
            {
                AudioListener.pause = true;
            }
            else
            {
                AudioListener.pause = false;
            }
        }
    }
    public void ControlsCheck()
    {
        if (PlayerPrefs.HasKey("FlipControls"))
        {
            if (PlayerPrefs.GetInt("FlipControls") > 0)
            {
                SinglePlayerControlsAreSwitched = true;
            }
            else
            {
                SinglePlayerControlsAreSwitched = false;
            }
        }
    }
    public void DualControlsCheck()
    {
        if (PlayerPrefs.HasKey("DualFlipControls"))
        {
            if (PlayerPrefs.GetInt("DualFlipControls") > 0)
            {
                DualPlayerControlsAreSwitched = true;
            }
            else
            {
                DualPlayerControlsAreSwitched = false;
            }
        }
    }

    public void OnclickContinue()
    {
        SceneManager.LoadScene(PlayerPrefs.GetInt("LastPlayedLvl", 1));
    }
    public void OnclickClose()
    {
        Settingpanel.SetActive(false);
    }
    public void OnclickSetting()
    {
        Settingpanel.SetActive(true);
    }
    public void LoadSingleplayer()
    {
        SceneManager.LoadScene(1);
    }

}
