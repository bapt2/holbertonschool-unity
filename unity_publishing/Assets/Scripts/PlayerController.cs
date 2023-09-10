using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed;
    int score = 0;
    public int health = 5;
    public GameObject teleporter1;
    public GameObject teleporter2;
    public GameObject winOrLose;

    public Text scoreText;
    public Text healthText;
    public Text WinLoseText;

    public Image WinLoseBG;

    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("menu");
        }
        if (health <= 0)
        {
            winOrLose.SetActive(true);
            WinLoseText.color = Color.white;
            WinLoseText.text = "Game Over!";
            WinLoseBG.color = Color.red;
            health = 5;
            score = 0;
            StartCoroutine(LoadScene(3));
        }
    }

    void FixedUpdate()
    {
        float horizontaleInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        rb.velocity = new Vector3(horizontaleInput, 0, verticalInput) * speed * Time.fixedDeltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pickup"))
        {
            score += 1;
            SetScoreText();
            Destroy(other.gameObject);
        }
        if (other.CompareTag("Trap"))
        {
            health -= 1;
            SetHealthText();
        }
        if (other.CompareTag("Goal"))
        {
            winOrLose.SetActive(true);
            WinLoseText.color = Color.black;
            WinLoseText.text = "You Win!";
            WinLoseBG.color = Color.green;
            StartCoroutine(LoadScene(3));
        }
        if (other.CompareTag("Teleporter"))
        {
            StartCoroutine(Teleport());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Teleporter"))
        {
            StopAllCoroutines();
        }
    }

    public IEnumerator Teleport()
    {
        if (Mathf.Approximately(transform.position.x, teleporter1.transform.position.x))
        {
            yield return new WaitForSeconds(2f);
            transform.position = new Vector3(teleporter2.transform.position.x, 1.2f, teleporter2.transform.position.z);
            Debug.Log("entrée");
        }
        else
        {
            yield return new WaitForSeconds(2f);
            transform.position = new Vector3(teleporter1.transform.position.x, 1.2f, teleporter1.transform.position.z);

            Debug.Log("sortie");
        }

    }

    public IEnumerator LoadScene(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void SetScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
    }

    void SetHealthText()
    {
        healthText.text = "Health: " + health.ToString();
    }
}
