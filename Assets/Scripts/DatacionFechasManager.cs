using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DatacionFechasManager : MonoBehaviour
{
    public GameObject panelInicio;
    public GameObject panelJuego;
    public GameObject panelCorrecto;
    public GameObject panelIncorrecto;

    public Text ingreso;

    string respuesta;
    string respuestaUsuario;

    void Start()
    {
        FindObjectOfType<AudioManager>().Play("Musica Datacion");

        panelInicio.SetActive(true);
        panelJuego.SetActive(false);
        panelCorrecto.SetActive(false);
        panelIncorrecto.SetActive(false);

        respuesta = "1926";
    }

    public void Juego()
    {
        panelInicio.SetActive(false);
        panelJuego.SetActive(true);
    }

    public void ValidarRespuesta()
    {
        respuestaUsuario = ingreso.text;
        if (respuestaUsuario == respuesta)
        {
            panelCorrecto.SetActive(true);
        }
        else
        {
            panelIncorrecto.SetActive(true);
        }
    }

    public void Continuar ()
    {
        FindObjectOfType<AudioManager>().Pause("Musica Datacion");
        SceneManager.LoadScene("Base");
    }

    public void Menu()
    {
        FindObjectOfType<AudioManager>().Pause("Musica Datacion");
        SceneManager.LoadScene("Menu");
    }

    public void Volver()
    {
        panelIncorrecto.SetActive(false);
        panelJuego.SetActive(true);
    }
}
