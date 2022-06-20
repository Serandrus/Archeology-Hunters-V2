using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public Text _textContador;
    private float _timeMax = 60f;

    [HideInInspector]
    public float _time;

    private void Start()
    {
        _time = _timeMax;
    }

    void Update()
    {
        _time -= Time.deltaTime;

        if (_time > -1)
        {
            _textContador.text = Mathf.Ceil(_time).ToString();
            if (_time < 10)
            {
                _textContador.color = Color.red;
            }
        }

        if (_time <= 0)
        {
            SceneManager.LoadScene("Base");
        }
    }
}
