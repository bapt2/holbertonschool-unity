using UnityEngine;

public class DeathZone : MonoBehaviour
{
    public PlayerController player;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player.Fell();
        }
    }
}
