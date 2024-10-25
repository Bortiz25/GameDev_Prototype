using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class FOV_Script : MonoBehaviour
{
   public float viewRadius;
   public float viewAngle;
   Mesh mesh = new Mesh();
   private void OnDrawGizmos() {
        print("Drawing Gizmos!");
        Handles.color = new Color(0,1,0,1f);
        Handles.DrawSolidDisc(transform.position, transform.up, viewRadius);
   }
   public Vector3 DirFromAngle(float angleInDegrees){
      return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad),0,Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));

   }
   private void initializeMesh(){
     Vector3[] vertices = new Vector3[3];
     Vector2[] uv = new Vector2[3];
     int[] triangles = new int[3];

     vertices[0] = Vector3.zero;
     vertices[1] = new Vector3(50,0);
     vertices[2] = new Vector3(0,-50);

     triangles[0] = 0;
     triangles[1] = 1;
     triangles[2] = 2;

     mesh.vertices = vertices;
     mesh.uv = uv;
     mesh.triangles = triangles;
   }
}
