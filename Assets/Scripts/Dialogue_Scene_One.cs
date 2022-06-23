using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue_Scene_One : MonoBehaviour
{
    public TextMeshProUGUI textComponent;

    public GameObject antonio;
    public string[] lines;
    public float textSpeed;

    public static int index;

    // Start is called before the first frame update
    void Start()
    {
        antonio.SetActive(true);
        antonio.transform.position = new Vector3(-0.14f, -0.3f, -10.8f);
        textComponent.text = string.Empty;
        StartDialogue();
    }

    // Update is called once per frame
    void Update()
    {
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
        FindObjectOfType<AudioManager>().Play("Linea de Dialogo 1");
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
                    FindObjectOfType<AudioManager>().Pause("Linea de Dialogo 1");
                    FindObjectOfType<AudioManager>().Play("Linea de Dialogo 2");
                    break;
                case 2:
                    FindObjectOfType<AudioManager>().Pause("Linea de Dialogo 2");
                    FindObjectOfType<AudioManager>().Play("Linea de Dialogo 3");
                    break;
                case 3:
                    FindObjectOfType<AudioManager>().Pause("Linea de Dialogo 3");
                    FindObjectOfType<AudioManager>().Play("Linea de Dialogo 4");
                    break;
            }
        }
        else
        {
            index = 4;
            FindObjectOfType<AudioManager>().Pause("Linea de Dialogo 4");
            antonio.SetActive(false);
            gameObject.SetActive(false);
        }
    }
}
