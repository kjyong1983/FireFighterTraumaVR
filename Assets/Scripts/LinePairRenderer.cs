using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinePairRenderer : MonoBehaviour {

    public GameObject[] froms;
    public GameObject[] tos;
    public Material lineMat;

    private void OnDrawGizmos()
    {
        DrawConnectingLines();
    }

    void OnPostRender()
    {
        DrawConnectingLines();
    }

    private void DrawConnectingLines()
    {
        for (int i = 0; i < froms.Length; i++)
        {
            Vector3 startPos = froms[i].transform.position;
            Vector3 endPos = tos[i].transform.position;

            GL.Begin(GL.LINES);
            lineMat.SetPass(0);
            GL.Color(
                new Color(
                    lineMat.color.r,
                    lineMat.color.g,
                    lineMat.color.b,
                    lineMat.color.a));
            GL.Vertex3(startPos.x, startPos.y, startPos.z);
            GL.Vertex3(endPos.x, endPos.y, endPos.z);
            GL.End();
        }
    }
}
