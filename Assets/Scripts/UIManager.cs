using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    public GameObject gameView;
    public GameObject settingsMenu;
    public GameObject inGameSettings;
    public bool isGame = false;

    void Awake()
    {
        gameObject.SetActive(true);
        gameView.SetActive(false);
        settingsMenu.SetActive(false);
        inGameSettings.SetActive(false);

    }

    public void OnStartClick()
    {
        gameObject.SetActive(false);
        gameView.SetActive(true);
        isGame = true;
    }

    public void OpenInGameSettings()
    {
        inGameSettings.SetActive(true);
    }

    public void OnSettingsClick()
    {
        settingsMenu.SetActive(true);
    }

    public void OnSettingsBackClick()
    {
        settingsMenu.SetActive(false);
    }

    public void OnInGameResumeClick()
    {
        gameView.SetActive(true);
        settingsMenu.SetActive(false);
        inGameSettings.SetActive(false);
    }

    public void OnInGameQuitClick()
    {
        gameView.SetActive(false);
        gameObject.SetActive(true);
        inGameSettings.SetActive(false);
    }

    public void OnQuitClick()
    {
        Application.Quit();
        Debug.Log("Quit.");
    }
}
