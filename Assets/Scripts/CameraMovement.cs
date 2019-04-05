using System.Collections;
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

    private Transform cameraTransform;
    private float zoomSpeed;
    private Vector3 moveVelocity;
    private Vector3 targetPos;

    [SerializeField] private CameraShake cameraShake;
    private bool isShaking = false;
    private float shakeTimeElapses;

    private void Awake()
    {
        cameraTransform = GetComponentInChildren<Camera>().transform;
        cameraShake.CameraShakeEvent.AddListener(StartShake);
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

    private void StartShake(float duration, float magnitude)
    {
        if (isShaking)
            StartCoroutine(Shake(duration, magnitude));
    }

    private IEnumerator Shake(float duration, float magnitude)
    {
        isShaking = true;

        Vector3 originalPos = cameraTransform.position;

        float elapsed = 0f;

        while (elapsed < duration)
        {
            cameraTransform.position = originalPos + Random.insideUnitSphere * magnitude;

            elapsed += Time.deltaTime;

            yield return null;
        }

        cameraTransform.position = originalPos;

        isShaking = false;
    }
}
