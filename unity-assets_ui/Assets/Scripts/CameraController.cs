using UnityEngine;

public class CameraController : MonoBehaviour
{
    public floa sensitivity;
    public float orbitDamping;
    public bool isInverted;
    public Transform player;
    Vector3 localRot;

    void Update()
    {
        transform.position = player.position;
        localRot.x += Input.GetAxis("Mouse X") * sensitivity;
        localRot.y -= Input.GetAxis("Mouse Y") * sensitivity;

        localRot.y = Mathf.Clamp(localRot.y, 0f, 80f);

        Quaternion qt = Quaternion.Euler(localRot.y, localRot.x, 0f);
        transform.rotation = Quaternion.Lerp(transform.rotation, qt, Time.deltaTime * orbitDamping);
    }
}
