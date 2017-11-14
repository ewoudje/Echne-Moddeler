using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{

    public int rows = 64;
    public int columns = 64;

    private Material lineMaterial;

    // Use this for initialization
    private void Start ()
    {
        lineMaterial = new Material(Shader.Find("Specular"));
        lineMaterial.color = Color.grey;
    }

    private void OnRenderObject()
    {
        lineMaterial.SetPass(0);

        GL.PushMatrix();
        GL.Begin(GL.LINES);
        GL.Color(Color.grey);
        /* Horizontal lines. */
        for (var i = -rows / 2; i <= rows / 2; i++)
        {
            GL.Vertex3(-columns / 2 / 8, 0, (float) i / 8);
            GL.Vertex3(columns / 2 / 8, 0, (float) i / 8);
        }
        /* Vertical lines. */
        for (var i = -columns / 2; i <= columns / 2; i++)
        {
            GL.Vertex3((float) i / 8 , 0, -rows / 2 / 8);
            GL.Vertex3((float) i / 8, 0, rows / 2 / 8);
        }
        GL.End();
        GL.PopMatrix();
    }
}
