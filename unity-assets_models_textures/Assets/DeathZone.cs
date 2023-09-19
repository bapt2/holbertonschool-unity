using UnityEngine;

public class DeathZone : MonoBehaviour
{
    public Transform player;
    public Transform spawn;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player.position = spawn.position;
        }
    }
}
