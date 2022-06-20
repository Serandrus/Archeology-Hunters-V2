using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Relic : MonoBehaviour
{
    public void DestoyRelic()
    {
        Destroy(gameObject);
        //StartCoroutine(Changer());
        ExManager.men.transform.GetChild(8).gameObject.SetActive(true);
        SceneManager.LoadScene("Base");
        Debug.Log("La reliquia ha sido encontrada");
    }

    IEnumerator Changer()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("Base");
    }

}
