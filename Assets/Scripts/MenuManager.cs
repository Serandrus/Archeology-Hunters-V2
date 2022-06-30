using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject menuPanel;
    public GameObject startPanel;
    public GameObject configPanel;
    public GameObject helpPanel;

    private void Start()
    {
        FindObjectOfType<AudioManager>().Play("Musica_Menu");
        startPanel.SetActive(true);
        menuPanel.SetActive(false);
        configPanel.SetActive(false);
        helpPanel.SetActive(false);
    }

    public void ActivateMenuPanel()
    {
        startPanel.SetActive(false);
        menuPanel.SetActive(true);
    }

    public void ConfigPanel()
    {
        menuPanel.SetActive(false);
        configPanel.SetActive(true);
    }

    public void BackToMenuFromConfig()
    {
        configPanel.SetActive(false);
        menuPanel.SetActive(true);
    }

    public void HelpPanel()
    {
        menuPanel.SetActive(false);
        helpPanel.SetActive(true);
    }
    public void BackToMenuFromHelp()
    {
        helpPanel.SetActive(false);
        menuPanel.SetActive(true);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Seleccion_Personaje");
        FindObjectOfType<AudioManager>().Pause("Musica_Menu");
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
