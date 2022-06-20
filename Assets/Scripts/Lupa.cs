using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lupa : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            LabGameManager.contador++;
        }
    }
}
