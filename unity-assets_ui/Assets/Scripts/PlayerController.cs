using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jumpForce;

    public Vector3 boxSize;
    public float maxDistance;
    public LayerMask layerMask;
    public Transform mainCamera;

    Vector3 direction;
    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float horizontale = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 camForward = mainCamera.forward;
        Vector3 camRight = mainCamera.right;

        camForward.y = 0;
        camRight.y = 0;

        Vector3 forwardRelative = vertical * camForward;
        Vector3 rightRelative = horizontale * camRight;

        Vector3 movDir = forwardRelative + rightRelative;

        rb.velocity = new Vector3(movDir.x, 0, movDir.z) * speed;
        if (Input.GetButtonDown("Jump") && GroundCheck())
        {
            rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
            Vector3 jumpforce = Vector3.up * jumpForce;
            rb.AddForce(jumpforce, ForceMode.Impulse);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawCube(transform.position - transform.up * maxDistance, boxSize);
    }

    bool GroundCheck()
    {
        if (Physics.BoxCast(transform.position, boxSize, -transform.up, transform.rotation, maxDistance, layerMask))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}