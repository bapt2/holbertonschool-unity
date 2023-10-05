using UnityEngine;

public class WinTrigger : MonoBehaviour
{
    public bool win = false;
    public GameObject winCanvas;

    private static WinTrigger instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("there is more thn  one instance of Wintrigger in the scene");
            return;
        }
        instance = this;
    }

    public static WinTrigger GetInstance()
    {
        return instance;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            winCanvas.SetActive(true);
            win = true;
        }
    }
}
