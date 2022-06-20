using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CargarPersonaje : MonoBehaviour
{
    public GameObject personaje_Masculino;
    public GameObject personaje_Femenino;

    public bool masculino;
    public bool femenino;

    // Update is called once per frame
    void Update()
    {
        masculino = PlayerPrefs.GetInt("masculinoSelected") == 1;
        femenino = PlayerPrefs.GetInt("femeninoSelected") == 1;

        if (masculino == true)
        {
            personaje_Masculino.SetActive(true);
            personaje_Femenino.SetActive(false);
        }

        if (femenino == true)
        {
            personaje_Femenino.SetActive(true);
            personaje_Masculino.SetActive(false);
        }
    }
}
