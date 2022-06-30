using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivarPanelesDialogo : MonoBehaviour
{
    public GameObject panel_Dialogos_1;
    public GameObject panel_Dialogos_2;

    public static bool isPanelActive;

    void Start()
    {
        panel_Dialogos_1.SetActive(false);
    }

    public void ActivarPanelDialogosUno()
    {
        isPanelActive = true;
        panel_Dialogos_1.SetActive(true);
    }

    public void ActivarPanelDialogosDos()
    {
        isPanelActive = true;
        panel_Dialogos_2.SetActive(true);
    }
}
