using UnityEngine;
using System.Collections;

[RequireComponent(typeof(LineRenderer))]
public class DrawOrbitScript: MonoBehaviour
{


    [Range(0.1f, 100f)]
    public float radius = 1.0f;

    [Range(3, 256)]
    public int numSegments = 128;

    void Start()
    {
        DoRenderer();
    }

    private bool IsHololens()
    {
        TransmitterStationControll control = this.gameObject.GetComponentInParent<TransmitterStationControll>();
        if (control)
        {
            return control.Hololens;
        }
        return false;
    }

    public void DoRenderer()
    {
        LineRenderer lineRenderer = gameObject.GetComponent<LineRenderer>();
        Color c1 = new Color(0.5f, 0.5f, 0.5f, 1);
        lineRenderer.material = new Material(Shader.Find("Particles/Additive"));
        lineRenderer.SetColors(c1, c1);
        if (IsHololens())
        {
            lineRenderer.SetWidth(0.002f, 0.002f);
        }
        else
        {
            lineRenderer.SetWidth(0.01f, 0.01f);
        }
        lineRenderer.SetVertexCount(numSegments + 1);
        lineRenderer.useWorldSpace = false;

        float deltaTheta = (float)(2.0 * Mathf.PI) / numSegments;
        float theta = 0f;

        for (int i = 0; i < numSegments + 1; i++)
        {
            float x = radius * Mathf.Cos(theta);
            float z = radius * Mathf.Sin(theta);
            Vector3 pos = new Vector3(x, 0, z);
            lineRenderer.SetPosition(i, pos);
            theta += deltaTheta;
        }
    }
}