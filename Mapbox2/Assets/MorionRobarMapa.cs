using System.IO;
using System.Collections.Generic;
using UnityEngine;

public class MorionRobarMapa : MonoBehaviour
{
    public int cuenta;
    private KeyCode screenshotKey;
    public MeshFilter mallaCopiar;
    public LayerMask capa;

	private void Start()
	{
        CapturarRelieve();
	}

	public Camera Camera
    {
        get
        {
            if (!_camera)
            {
                _camera = GetComponent<Camera>();
            }
            return _camera;
        }
    }
    public Camera _camera;

	private void OnDrawGizmosSelected()
	{
		
        if (Input.GetKeyDown(screenshotKey))
        {
            CapturarFoto();
        }

        Vector3[] vertices = mallaCopiar.sharedMesh.vertices;
        List<Vector3> verticesNuevos = new List<Vector3>();
        for (int i = 0; i < mallaCopiar.sharedMesh.vertexCount; i++)
        {
            Gizmos.color = Color.red;
           // Debug.DrawLine(mallaCopiar.transform.position + vertices[i] + Vector3.up * transform.position.y, mallaCopiar.transform.position + vertices[i] + Vector3.up * transform.position.y + Vector3.down*200);
        }
    }
    [ContextMenu("Capturar")]
    public void CapturarFoto()
    {
        RenderTexture activeRenderTexture = RenderTexture.active;
        RenderTexture.active = Camera.targetTexture;

        Camera.Render();

        Texture2D image = new Texture2D(Camera.targetTexture.width, Camera.targetTexture.height);
        image.ReadPixels(new Rect(0, 0, Camera.targetTexture.width, Camera.targetTexture.height), 0, 0);
        image.Apply();
        RenderTexture.active = activeRenderTexture;

        byte[] bytes = image.EncodeToPNG();
        Destroy(image);

        File.WriteAllBytes(Application.dataPath + "/MorionMapa/Fondos/" + cuenta + ".png", bytes);
        cuenta++;
    }

    [ContextMenu("Capturar Relieve")]
    public void CapturarRelieve()
	{
        Vector3[] vertices = mallaCopiar.sharedMesh.vertices;
        List<Vector3> verticesNuevos = new List<Vector3>();
		for (int i = 0; i < mallaCopiar.sharedMesh.vertexCount; i++)
		{
            RaycastHit hit;
            Ray rayo = new Ray(mallaCopiar.transform.position + vertices[i] + Vector3.up * transform.position.y, Vector3.down);
			if (Physics.Raycast(rayo, out hit, 500, capa))
			{
                vertices[i] = hit.point - mallaCopiar.transform.position;
			}
			else
			{
                print("no dio");
			}
            verticesNuevos.Add(vertices[i]);
		}
        mallaCopiar.sharedMesh.SetVertices(verticesNuevos);
        mallaCopiar.sharedMesh.RecalculateBounds();
        mallaCopiar.sharedMesh.RecalculateNormals();
	}
}