using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExManager : MonoBehaviour
{
    public GameObject relic;
    public GameObject imagenReliquia;

    public static GameObject men;

    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<AudioManager>().Play("Musica Excavacion");

        imagenReliquia.SetActive(false);
        men = GameObject.FindGameObjectWithTag("Player");
        men.GetComponent<MovimientoReal>().enabled = false;
        //Invoke("Relic", 0.5f);
        Reliquia();
        men.transform.GetChild(2).gameObject.SetActive(false);
    }

    public void Update()
    {
        if (Relic.takenRelic == true)
        {
            imagenReliquia.SetActive(true);
            StartCoroutine(Changer());
        }
    }

    void Reliquia()
    {
        Instantiate(relic, new Vector3(Random.Range(-50f, 50f), 0.5f, Random.Range(-50f, 50f)), Quaternion.identity);
    }

    IEnumerator Changer()
    {
        Relic.takenRelic = false;
        yield return new WaitForSeconds(3);
        men.GetComponent<MovimientoReal>().enabled = true;
        men.transform.GetChild(2).gameObject.SetActive(true);

        FindObjectOfType<AudioManager>().Pause("Musica Excavacion");
        SceneManager.LoadScene("Base");
    }
}
