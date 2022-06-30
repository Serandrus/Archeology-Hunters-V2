using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Relic : MonoBehaviour
{
    public static bool takenRelic = false;

    public void DestoyRelic()
    {
        Destroy(gameObject);
        //StartCoroutine(Changer());
        //ExManager.men.transform.GetChild(8).gameObject.SetActive(true);
        //SceneManager.LoadScene("Base");
        takenRelic = true;
    }

    

}
