using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FruitNinja {

  public class LineController : MonoBehaviour {

    private Camera mainCamera;
    [SerializeField] private LineRenderer lineRenderer;
    public float timerFade;
    private float currentTimer;
    public int maxPoints;
    private List<Vector3> points = new List<Vector3>();
    private Vector3 lastPos;
    private MeshCollider meshCollider;
    private Mesh mesh;


    private void Awake() {
      mainCamera = FindObjectOfType<Camera>();
      meshCollider = lineRenderer.gameObject.AddComponent<MeshCollider>();
      mesh = new Mesh();
      lineRenderer.BakeMesh(mesh, true);
      meshCollider.sharedMesh = mesh;
    }

    private void Update() {
      currentTimer += Time.deltaTime;
      if (timerFade < currentTimer) {
        currentTimer = 0;
        TryDeletePoint();
      }

      if (Input.GetMouseButtonDown(0)) {
        SetPointToLine(Input.mousePosition);
      }

      var pos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
      pos = new Vector3(pos.x, pos.y, 0);
      
      if (Input.GetMouseButton(0) && lastPos != pos && lineRenderer.positionCount < maxPoints) {
        SetPointToLine(pos);
      }

      if (Input.GetMouseButtonUp(0)) {
        points.Clear();
        lineRenderer.positionCount = 0;
        lineRenderer.BakeMesh(mesh, true);
        meshCollider.sharedMesh = mesh;
      }
    }


    private void SetPointToLine(Vector3 pos) {
      // var pos =mainCamera.ScreenToWorldPoint(mousePos);
      points.Add(pos);
      var positionCount = points.Count;
      lineRenderer.positionCount = positionCount;
      lineRenderer.SetPosition(positionCount - 1, pos);
      lastPos = pos;
      lineRenderer.BakeMesh(mesh, true);
      meshCollider.sharedMesh = mesh;
    }

    private void TryDeletePoint() {
      if (points.Count <= 0) {
        return;
      }
      points.RemoveAt(0);
      lineRenderer.positionCount = points.Count;
      lineRenderer.SetPositions(points.ToArray());
      lineRenderer.BakeMesh(mesh, true);
      meshCollider.sharedMesh = mesh;
    }


  }

}
