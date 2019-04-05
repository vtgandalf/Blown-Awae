using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraMovement : MonoBehaviour
{
    public float dampTime = 0.2f;
    public float zoomOffset = -25f;
    public float minZoom = 30f;
    public float maxZoom = 5f;
    public Vector3 offset = Vector3.zero;
    [SerializeField] private PlayerRuntimeSet players;

    private Camera camera;
    private float zoomSpeed;
    private Vector3 moveVelocity;
    private Vector3 targetPos;

    private void Awake()
    {
        camera = GetComponent<Camera>();
    }

    private void FixedUpdate()
    {
        if (players.Items.Count == 0)
            return;
        
        Move();
    }

    private void Move()
    {
        FindAveragePosition();
        Vector3 zoom = GetZoom();

        targetPos += offset + zoom;

        transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref moveVelocity, dampTime);
    }

    private void FindAveragePosition()
    {
        Vector3 averagePos = Vector3.zero;
        int numTargets = 0;

        foreach (Player p in players.Items)
        {
            averagePos += p.transform.position;
            numTargets++;
        }

        if (numTargets >= 0)
            averagePos /= numTargets;

        targetPos = averagePos;
    }

    private Vector3 GetZoom()
    {
        float distance = FindGreatestDistance();
        return (Mathf.Clamp(distance, maxZoom, minZoom) + zoomOffset) * -transform.forward;
    }

    private float FindGreatestDistance()
    {
        Bounds bounds = new Bounds(players.Items[0].transform.position, Vector3.zero);
        foreach (Player p in players.Items)
        {
            bounds.Encapsulate(p.transform.position);
        }

        return bounds.size.x > bounds.size.z ? bounds.size.x : bounds.size.z;
    }
}
