using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOfText : MonoBehaviour
{
    public GameObject _Image;
    public GameObject _Button;
    // Start is called before the first frame update
    void Start()
    {
        _Image.SetActive(true);
        _Button.SetActive(true);
    }

    public void StopShowing()
    {
        _Image.SetActive(false);
        _Button.SetActive(false);
    }
}
