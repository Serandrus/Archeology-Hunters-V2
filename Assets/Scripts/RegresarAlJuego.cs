using UnityEngine;
using UnityEngine.SceneManagement;

public class RegresarAlJuego : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            SceneManager.LoadScene("Base");
        }
    }
}