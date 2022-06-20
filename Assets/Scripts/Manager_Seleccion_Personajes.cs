﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager_Seleccion_Personajes : MonoBehaviour
{
    public GameObject personaje_Masculino;
    public GameObject personaje_Femenino;
    public GameObject boton_Seleccion;

    public bool masculino;
    public bool femenino;

    private void Awake()
    {
        masculino = PlayerPrefs.GetInt("masculinoSelected") == 1;
        femenino = PlayerPrefs.GetInt("femeninoSelected") == 1;
    }

    // Start is called before the first frame update
    void Start()
    {
        personaje_Masculino.SetActive(false);
        personaje_Femenino.SetActive(false);
        boton_Seleccion.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (masculino == false && femenino == false)
        {
            masculino = true;
        }

        if (Dialogue_Scene_One.index == 4)
        {
            StartCoroutine(AparecerPersonajes());
        }
    }

    public void PersonajeMasculino()
    {
        masculino = true;
        femenino = false;
        GuardarPersonaje();
    }

    public void PersonajeFemenino()
    {
        femenino = true;
        masculino = false;
        GuardarPersonaje();
    }

    public void GuardarPersonaje()
    {
        PlayerPrefs.SetInt("masculinoSelected", masculino ? 1 : 0);
        PlayerPrefs.SetInt("femeninoSelected", femenino ? 1 : 0);
    }

    public void Juego()
    {
        GuardarPersonaje();
        SceneManager.LoadScene("Base");
    }

    IEnumerator AparecerPersonajes()
    {
        yield return new WaitForSeconds(4);
        personaje_Masculino.SetActive(true);
        personaje_Femenino.SetActive(true);
        boton_Seleccion.SetActive(true);
    }
}
