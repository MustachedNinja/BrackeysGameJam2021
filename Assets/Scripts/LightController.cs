using UnityEngine;

public class LightController : MonoBehaviour
{

    [SerializeField]
    private GameObject player1;
    [SerializeField]
    private GameObject player2;
    private Light[] lights;

    [SerializeField]
    private float lightThreshold = 5f;
    [SerializeField]
    private float intensity = 10f;
    void Start()
    {
        lights = transform.GetComponentsInChildren<Light>(true);
    }

    void SetIntensity(float intensity) {
        foreach(Light l in lights) {
            l.intensity = intensity;
        }
    }

    void Update() {
        if (Vector3.Distance(player1.transform.position, player2.transform.position) < lightThreshold) {
            SetIntensity(intensity);
        } else {
            SetIntensity(0);
        }
    }
}
