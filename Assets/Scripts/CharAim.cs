using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharAim : MonoBehaviour
{
    float mouseX; //variable destinada al eje x que hace referencia al mouse.
    float mouseY; //variable destinada al eje y que hace referencia al mouse.
    public bool invertmouse; //variable destinada para invertir la vista vertical

    public float yMin = -50.0f, yMax = 50.0f;
    public int cases;

    void Start()
    {
        if (gameObject.tag == "MainCamera")
        {
            cases = 1;
        }
        else
        {
            cases = 2;
        }
    }

    void Update()
    {
        switch (cases)
        {
            case 1:
                mouseX += Input.GetAxis("Mouse X"); //acoplando la variable al input del eje x del propio mouse
                if (invertmouse) //función para identificar si la inversion de la vista está activa
                {
                    mouseY += Input.GetAxis("Mouse Y"); //acoplando la variable al input del eje y del propio mouse
                    mouseY = Mathf.Clamp(mouseY, yMin, yMax); //evita que la camara en el eje y rote, solo hasta las coordenadas designadas
                }
                else
                {
                    mouseY -= Input.GetAxis("Mouse Y"); //acoplando la variable al input del eje y del propio mouse
                    mouseY = Mathf.Clamp(mouseY, yMin, yMax); //evita que la camara en el eje y rote, solo hasta las coordenadas designadas
                }

                transform.eulerAngles = new Vector3(mouseY, mouseX, 0); //mueve la cámara en los ejes x y y.
                break;
            case 2:
                mouseX += Input.GetAxis("Mouse X");
                transform.eulerAngles = new Vector3(0f, mouseX, 0f);
                break;
        }
    }
}
