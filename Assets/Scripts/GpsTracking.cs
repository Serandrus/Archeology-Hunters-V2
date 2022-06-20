using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GpsTracking : MonoBehaviour
{
    public Vector3 anchor = new Vector3(6.264580000578248f,0, -75.5626535619031f);
    public Vector3 anchorDos = new Vector3(6.263319683214237f,0, -75.56046311502443f);

    //private Vector3 poiSalsipuedes = new Vector3(6.261373463578357f, 0, -75.56114974171267f);

    public float max;
    [Range(0, 1)]
    public float multiplier;
    public Transform _transform;
    public Transform objRef;

    void Update()
    {
        Vector3 resta = (anchorDos - anchor);
        
        resta.z *= -1;
        _transform.position = objRef.position + resta * max * multiplier;
    }

    public void CambiarMaximo(string s)
    {
        max = float.Parse(s);
    }
}
