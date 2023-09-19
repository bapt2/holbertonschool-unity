using UnityEngine;

public class Spawn : MonoBehaviour
{
    public Transform player;

    private void Start()
    {
        player.position = transform.position;
    }
}
