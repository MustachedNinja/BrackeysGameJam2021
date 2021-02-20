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
    void LateUpdate()
    {
        Vector3 center = new Vector3((player1.gameObject.transform.position.x + player2.gameObject.transform.position.x) / 2, 0, 0);
        Vector3 targetPosition = center + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, targetPosition, smoothSpeed * Time.deltaTime);
        transform.position = smoothedPosition;
    }
}
