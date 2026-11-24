using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class MovingSideways : MonoBehaviour
{
    [SerializeField] private Vector3 travelOffset = new Vector3(0f, 0f, 6f);
    [SerializeField, Min(0.1f)] private float secondsOneWay = 2f;

    private Rigidbody body;
    private Vector3 startPosition;
    private float elapsed;

    private void Awake()
    {
        body = GetComponent<Rigidbody>();
        startPosition = body.position;
    }

    private void FixedUpdate()
    {
        elapsed += Time.fixedDeltaTime;
        float progress = Mathf.PingPong(elapsed / secondsOneWay, 1f);
        body.MovePosition(startPosition + travelOffset * progress);
    }
}