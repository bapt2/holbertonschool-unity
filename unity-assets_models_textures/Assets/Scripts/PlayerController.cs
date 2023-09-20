using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 0;
    public float jumpForce = 0;

    public Vector3 boxSize;
    public Vector3 direction;
    public float maxDistance;
    public LayerMask layerMask;
    public Camera mainCamera;

    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float horizontale = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        direction = Quaternion.Euler(0, mainCamera.transform.eulerAngles.y, 0) * new Vector3(horizontale, 0, vertical);
        direction.Normalize();

        rb.velocity = new Vector3(horizontale, 0, vertical) * speed * Time.fixedDeltaTime;
        if (Input.GetKeyDown(KeyCode.Space) && GroundCheck())
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
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
