using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Charger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EEE());
    }

    IEnumerator EEE()
    {
        yield return new WaitForSeconds(10);
        GotoExc();
    }

    public void GotoExc()
    {
        SceneManager.LoadScene("Excavar");
    }
}
