using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LabGameManager : MonoBehaviour
{
    public GameObject exit;
    public GameObject exitButton;
    public GameObject PanelInicio;

    public Text ScoreText;

    public static int contador;

    // Start is called before the first frame update
    void Start()
    {
        exit.GetComponent<Renderer>().material.color = Color.red;
        exitButton.GetComponent<Image>().material.color = Color.white;
        PanelInicio.SetActive(true);
        exitButton.SetActive(false);
        contador = 0;

        if (contador>= 4)
        {
            contador = 0;
        }
    }

    private void Update()
    {
        switch (contador)
        {
            default:
                if (contador == 0)
                {
                    ScoreText.text = "0/3";
                }
                break;
            case 1:
                if (contador == 1)
                {
                    ScoreText.text = "1/3";
                }
                break;
            case 2:
                if (contador == 2)
                {
                    ScoreText.text = "2/3";
                }
                break;
            case 3:
                if (contador == 3)
                {
                    ScoreText.text = "3/3";
                    exit.GetComponent<Renderer>().material.color = Color.green;
                    exitButton.SetActive(true);
                }
                break;
        }
    }

    public void StartGame()
    {
        PanelInicio.SetActive(false);
    }

    public void WinCondition()
    {
        if (contador == 3)
        {
            SceneManager.LoadScene("Base");
        }
    }
}
