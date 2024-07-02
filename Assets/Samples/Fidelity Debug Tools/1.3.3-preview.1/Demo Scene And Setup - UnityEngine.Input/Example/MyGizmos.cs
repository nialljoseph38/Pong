using System;
using UnityEngine;
using Fidelity.DebugTools;
using UnityEngine.SceneManagement;

public class MyGizmos : MonoBehaviour {

    public bool drawStandardSphere;
    public bool drawFidelityDebugSphere;
    public bool createMarker;

    private GameObject sphere;
    private bool hasSphere;

    float currentAngle = 0.0f;
    float angularSpeed = 50.0f;
    Vector3 radius = new Vector3(0, 0, 3.0f);

    private DebugGizmos debugGizmos;

    private void OnDrawGizmos() {
        DrawSpheres();

    }

    private void DrawSpheres() {
        if (drawStandardSphere) {
            Gizmos.color = Color.yellow;
            Gizmos.DrawSphere(Vector3.zero, 1);
        }

        if (drawFidelityDebugSphere) {
            if (!hasSphere) {
                sphere = debugGizmos.DrawSphere(Vector3.zero, 1, Color.red);
                sphere.name = "Fidelity Debug Sphere";
                hasSphere = true;
            }
        }
        else {
            if(hasSphere) {
                DestroyImmediate(sphere);
                hasSphere = false;
            }
        }

        if(hasSphere) {
            Vector3 positionOnOrbit = Vector3.zero + Quaternion.AngleAxis(currentAngle += angularSpeed * Time.deltaTime, Vector3.up) * radius;
            debugGizmos.UpdateSphere(sphere, positionOnOrbit, 1f);
        }

        if (createMarker) {
            debugGizmos.DrawMarker(Vector3.one, 2f, Color.blue);
        }
    }

}
