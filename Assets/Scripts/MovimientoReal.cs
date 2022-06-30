using System.Collections;
using UnityEngine;
using UnityEngine.Android;
using UnityEngine.UI;

public class MovimientoReal : MonoBehaviour
{
    public static MovimientoReal instance = null;
    public Text gpsTextOut;
    public Vector3 coordenadas;
    public Vector3 anchor = new Vector3(6.264580000578248f, 0, -75.5626535619031f);
    public GameObject ancla;

    public float max;
    [Range(0, 1)]
    public float multiplier;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        ancla.GetComponent<GameObject>();
        ancla.transform.position = anchor;
        StartCoroutine(GPSLocation());
        DontDestroyOnLoad(this);
    }

    void Update()
    {
        coordenadas = new Vector3(Input.location.lastData.latitude, 0, Input.location.lastData.longitude);
        Vector3 resta = (coordenadas - anchor);
        resta.z *= -1;
        transform.position = ancla.transform.position + resta * max * multiplier;
    }

    private IEnumerator GPSLocation()
    {
        while (true)
        {
            yield return new WaitForSeconds(3);

            if (!Permission.HasUserAuthorizedPermission(Permission.FineLocation))
            {
                Permission.RequestUserPermission(Permission.FineLocation);
                Permission.RequestUserPermission(Permission.CoarseLocation);

                if (!Input.location.isEnabledByUser)
                {
                    yield return new WaitForSeconds(3);
                }

                Input.location.Start();
                int maxWait = 5;

                while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
                {
                    yield return new WaitForSeconds(3);
                    maxWait--;
                }

                if (maxWait < 3)
                {
                    //gpsTextOut.text = "Timed Out";
                    print("Timed Out");
                    yield return new WaitForSeconds(3);
                }

                if (Input.location.status == LocationServiceStatus.Failed)
                {
                    gpsTextOut.text = "Unable to determine device location";
                    print("Unable to determine device location");
                    yield return new WaitForSeconds(3);
                }
                else
                {
                    gpsTextOut.text = "Location: " + Input.location.lastData.latitude + " " + Input.location.lastData.longitude;
                    print("Location: " + Input.location.lastData.latitude + " " + Input.location.lastData.longitude);
                }
            }
        }
    }


}
