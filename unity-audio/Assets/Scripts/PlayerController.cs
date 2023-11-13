using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jumpForce;

    public Vector3 boxSize;
    public float maxDistance;
    public LayerMask layerMask;
    public Transform mainCamera;

    bool isJumping = false;
    public bool falling = false;
    public bool isGrouded = true;

    public Animator animator;

    public GameObject model;

    public Transform respawn;

    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (GroundCheck())
        {
            isGrouded = true;
        }
        else
        {
            isGrouded = false;
        }
    }

    void FixedUpdate()
    {
        if(isGrouded)
        {
            isJumping = false;
            falling = false;
            animator.SetBool("Grounded", isGrouded);
            animator.SetBool("Jump", isJumping);
            animator.SetBool("Respawn", falling);
        }
        float horizontale = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 camForward = mainCamera.forward;
        Vector3 camRight = mainCamera.right;

        //camForward.y = 0;
        //camRight.y = 0;

        Vector3 forwardRelative = vertical * camForward;
        Vector3 rightRelative = horizontale * camRight;

        Vector3 movDir = forwardRelative + rightRelative;

        rb.velocity = new Vector3(0, 0, movDir.z) * speed;
        model.transform.eulerAngles = new Vector3(0, rightRelative.x, 0) * speed;

        float characterXVelocity = Mathf.Abs(rb.velocity.x);
        float characterZVelocity = Mathf.Abs(rb.velocity.z);

        animator.SetFloat("velocityX", characterXVelocity);
        animator.SetFloat("velocityZ", characterZVelocity);

        if (Input.GetButtonDown("Jump"))
        {
            if (isGrouded)
            {
                isJumping = true;
                rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
                Vector3 jumpforce = Vector3.up * jumpForce;
                rb.AddForce(jumpforce, ForceMode.Impulse);
                
                animator.SetBool("Jump", isJumping);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawCube(transform.position - transform.up * maxDistance, boxSize);
    }

    public void Fell()
    {
        transform.position = respawn.position;
        falling = true;
        animator.SetBool("Respawn", falling);
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