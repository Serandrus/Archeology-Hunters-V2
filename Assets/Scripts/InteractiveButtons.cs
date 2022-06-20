using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InteractiveButtons : MonoBehaviour
{

    public void BackToGameEx()
    {
        ExManager.men.transform.GetChild(8).gameObject.SetActive(true);
        SceneManager.LoadScene("Base");
    }

    public void RestartEx()
    {
        SceneManager.LoadScene("Excavar");
    }

    public void BackToGameLab()
    {
        SceneManager.LoadScene("Base");
    }

    public void RestartLab()
    {
        SceneManager.LoadScene("Laberinto");
    }
}
