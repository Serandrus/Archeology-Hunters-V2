using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Dialogue_Scene_Three : MonoBehaviour
{
    public TextMeshProUGUI textComponent;

    public string[] lines;
    public float textSpeed;

    public static int index;

    void Start()
    {
        textComponent.text = string.Empty;
        //StartDialogue();
    }

    void Update()
    {
        if (ActivarPanelesDialogo.isPanelActive == true)
        {
            StartDialogue();
            FindObjectOfType<AudioManager>().Play("Linea de Dialogo 9");
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

            switch (index)
            {
                case 1:
                    FindObjectOfType<AudioManager>().Pause("Linea de Dialogo 9");
                    FindObjectOfType<AudioManager>().Play("Linea de Dialogo 10");
                    break;
                case 2:
                    FindObjectOfType<AudioManager>().Pause("Linea de Dialogo 10");
                    FindObjectOfType<AudioManager>().Play("Linea de Dialogo 11");
                    break;
                case 3:
                    FindObjectOfType<AudioManager>().Pause("Linea de Dialogo 11");
                    FindObjectOfType<AudioManager>().Play("Linea de Dialogo 12");
                    break;
            }
        }
        else
        {
            index = 4;
            FindObjectOfType<AudioManager>().Pause("Linea de Dialogo 12");
            gameObject.SetActive(false);
            SceneManager.LoadScene("Excavar");
        }
    }
}
