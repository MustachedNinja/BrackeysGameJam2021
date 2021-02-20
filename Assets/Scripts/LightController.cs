using UnityEngine;

public class LightController : MonoBehaviour
{

    [SerializeField]
    private GameObject player1 = null;
    [SerializeField]
    private GameObject player2 = null;
    private Light[] lights;

    [SerializeField]
    private float minIntensityDistance = 15f;
    [SerializeField]
    private float maxIntensityDistance = 5f;
    [SerializeField]
    private float maxIntensity = 1f;
    void Start()
    {
        lights = transform.GetComponentsInChildren<Light>(true);
    }

    void SetIntensity(float intensity) {
        foreach(Light l in lights) {
            l.intensity = intensity;
        }
    }

    float CalculateIntensity(Vector3 player1Pos, Vector3 player2Pos) {
        float distance = Vector3.Distance(player1Pos, player2Pos);
        if (distance > minIntensityDistance) {
            return 0;
        } else if (distance < maxIntensityDistance) {
            return maxIntensity;
        } else {
            return Mathf.InverseLerp(minIntensityDistance, maxIntensityDistance, distance) * maxIntensity;
        }
    }

    void Update() {
        SetIntensity(CalculateIntensity(player1.transform.position, player2.transform.position));
    }
}
