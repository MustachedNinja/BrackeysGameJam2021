using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    Vector3 offset = new Vector3(0f, 0.125f, -4f);
    [SerializeField]
    private GameObject player1 = null;
    [SerializeField]
    private GameObject player2 = null;
    [SerializeField]
    private float smoothSpeed = 10f;

    [SerializeField]
    private bool zoom = true;
    void LateUpdate()
    {
        float maxOffCenter = 0;
        if (zoom) {
            maxOffCenter = Mathf.Max(Mathf.Abs(player1.transform.position.y), Mathf.Abs(player2.transform.position.y));
        }
        Vector3 center = new Vector3((player1.transform.position.x + player2.transform.position.x) / 2, 0, -maxOffCenter * 1.5f);
        Vector3 targetPosition = center + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, targetPosition, smoothSpeed * Time.deltaTime);
        transform.position = smoothedPosition;
    }
}
