using UnityEngine;
using UnityEngine.SceneManagement;

public class CambiarALaberinto : MonoBehaviour
{
    public void GotoLab()
    {
        SceneManager.LoadScene("Laberinto");
    }

    public void GotoGame()
    {
        SceneManager.LoadScene("Base");
    }

    public void GotoExc()
    {
        SceneManager.LoadScene("Excavar");
    }

    public void GotoDate()
    {
        SceneManager.LoadScene("Datacion_Fechas");
    }
}
