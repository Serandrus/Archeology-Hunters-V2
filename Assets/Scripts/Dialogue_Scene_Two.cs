using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Dialogue_Scene_Two : MonoBehaviour
{
    public TextMeshProUGUI textComponent;

    public string[] lines;
    public float textSpeed;

    public static int index;

    // Start is called before the first frame update
    void Start()
    {
        textComponent.text = string.Empty;
        //StartDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        if (ActivarPanelesDialogo.isPanelActive == true)
        {
            StartDialogue();
            ActivarPanelesDialogo.isPanelActive = false;
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (textComponent.text == lines[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = lines[index];
            }
        }
    }

    void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        //Escribe el texto letra a letra
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            index = 4;
            gameObject.SetActive(false);
            SceneManager.LoadScene("Laberinto");
        }
    }
}
