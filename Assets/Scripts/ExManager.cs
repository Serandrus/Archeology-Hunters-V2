using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExManager : MonoBehaviour
{
    public GameObject relic;

    public static GameObject men;

    // Start is called before the first frame update
    void Start()
    {
        men = GameObject.FindGameObjectWithTag("Player");
        //men.GetComponent<Camera>().enabled = false;
        Invoke("Relic", 0.5f);
        men.transform.GetChild(8).gameObject.SetActive(false);
    }

    void Relic()
    {
        Instantiate(relic, new Vector3(Random.Range(-50f, 50f), 0.5f, Random.Range(-50f, 50f)), Quaternion.identity);
    }

    void EnablingCam()
    {
        if (true)
        {

        }
        men.transform.GetChild(8).gameObject.SetActive(true);
    }
}
