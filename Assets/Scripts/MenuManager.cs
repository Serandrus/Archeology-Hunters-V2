using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    private void Start()
    {
        FindObjectOfType<AudioManager>().Play("Efectos_Sonido_4");
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Seleccion_Personaje");
        FindObjectOfType<AudioManager>().Pause("Efectos_Sonido_4");
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
