using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float timeOffSet;
    public float sensitivity;
    public Transform player;
    public Vector3 turn;
    public Vector3 posOffSet;
    Vector3 velocity;

    private void Start()
    {
        posOffSet = transform.position - player.position;
    }

    void Update()
    {
        turn.x += Input.GetAxis("Mouse X") * sensitivity;
        turn.y += Input.GetAxis("Mouse Y") * sensitivity;

        posOffSet = Quaternion.AngleAxis(turn.x * sensitivity, Vector3.up) * Quaternion.AngleAxis(turn.y * sensitivity, Vector3.left) * posOffSet;
        transform.position = player.position + posOffSet;
        transform.LookAt(player.position);
    }
}
