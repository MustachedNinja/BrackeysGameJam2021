using UnityEngine;

public class LevelComplete : MonoBehaviour
{
    [SerializeField]
    private GameObject levelCompleteUI = null;

    private bool player1InBounds = false;
    private bool player2InBounds = false;
    void OnTriggerStay(Collider other) {
        if (other.gameObject.name == "Player1") {
            player1InBounds = true;
        } else if (other.gameObject.name == "Player2") {
            player2InBounds = true;
        }
    }

    void OnTriggerExit(Collider other) {
        if (other.gameObject.name == "Player1") {
            player1InBounds = false;
        } else if (other.gameObject.name == "Player2") {
            player2InBounds = false;
        }
    }

    void Update() {
        if (player1InBounds && player2InBounds) {
            levelCompleteUI.SetActive(true);
        }
    }
}
