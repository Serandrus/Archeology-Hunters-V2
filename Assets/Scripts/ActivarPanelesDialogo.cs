using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivarPanelesDialogo : MonoBehaviour
{
    public GameObject panel_Dialogos_1;

    public static bool isPanelActive;

    // Start is called before the first frame update
    void Start()
    {
        panel_Dialogos_1.SetActive(false);
    }

    public void ActivarPanelDialogosUno()
    {
        isPanelActive = true;
        panel_Dialogos_1.SetActive(true);
    }
}
