using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class FingerTrail : MonoBehaviour
{
    private TrailRenderer trail;
    public int layer;
    private void Start()
    {
        trail = GetComponent<TrailRenderer>();
        trail.Clear();
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            trail.Clear();
            trail.AddPosition(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        }
        if (Input.GetMouseButton(0))
        {
            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(transform.position.x, transform.position.y, layer);

        }
        if (Input.GetMouseButtonUp(0))
        {
            trail.Clear();
        }
    }
}
