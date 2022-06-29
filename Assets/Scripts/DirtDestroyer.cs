using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirtDestroyer : MonoBehaviour
{
    public GameObject dirtDestroyedEffect;

    public void DestoyDirt()
    {
        GameObject effectInst = (GameObject)Instantiate(dirtDestroyedEffect, transform.position, transform.rotation);
        Destroy(gameObject);
        Destroy(effectInst, 2f);
    }
}
