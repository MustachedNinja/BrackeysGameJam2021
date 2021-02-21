using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    Rigidbody rb;

    [SerializeField]
    private LevelManager manager = null;

    float direction;
    [SerializeField]
    private float movementSpeed = 3;
    [SerializeField]
    private float jumpHeight = 10f;
    private float distToGround = 0f;
    private bool attemptJump = false;
    void Awake() {
        rb = gameObject.GetComponent<Rigidbody>();
    }
    
    void Start() {
        distToGround = gameObject.GetComponent<Collider>().bounds.extents.y;
    }

    public void OnJumpInput() {
        attemptJump = true;
    }

    void Jump() {
        rb.AddForce(0, 50 * jumpHeight, 0);
    }

    public void OnMoveInput(float direction) {
        this.direction = direction;
    }

    bool IsGrounded() {
        return Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.1f);
    }

    void Update() {
        if (transform.position.y < -10f) {
            manager.ReloadLevel();
        }
        transform.position = new Vector3(transform.position.x + (direction * movementSpeed * Time.deltaTime), transform.position.y, 0);
        if (IsGrounded() && attemptJump) {
            Jump();
        }
        attemptJump = false;
        transform.rotation = Quaternion.identity;
    }
}
