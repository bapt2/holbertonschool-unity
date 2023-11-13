using UnityEngine;

public class TimeTrigger : MonoBehaviour
{
    public Timer timer;
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            timer.enabled = true;
        }
    }
}
