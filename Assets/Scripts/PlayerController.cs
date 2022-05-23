using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private float speed = 40f;
    private Rigidbody playerRb;
    private float topeEnZ = 8;
    private float topeEnX = 14;
    [SerializeField] Slider vida;
    [SerializeField] Text scoreCount;
    [SerializeField] TextMeshProUGUI gameOver;
    private int maxVida = 100;
    private int actualVida;
    private int score = 0;
    private bool muerto = false;

    public bool Dead { get { return muerto; } } // ENCAPSULATION

    void Start()
    {
        actualVida = maxVida;
        vida.maxValue = maxVida;
        vida.value = actualVida;
        playerRb = GetComponent<Rigidbody>();
        scoreCount.text = "Score: " + score.ToString();
        gameOver.gameObject.SetActive(false);
    }

    void Update()
    {
        if (actualVida <= 0)
            muerto = true;

        if (muerto)
        {
            gameOver.gameObject.SetActive(true);
            StartCoroutine(RecargaPartida());
            return;
        }

        MovePlayer();
        ConstrainPlayerPosition();
    }
    void MovePlayer() // ABSTRACTION
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        playerRb.AddForce(Vector3.forward * speed * verticalInput);
        playerRb.AddForce(Vector3.right * speed * horizontalInput);
    }

    void ConstrainPlayerPosition() // ABSTRACTION
    {
        if (transform.position.z < -topeEnZ)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -topeEnZ);
        }
        if (transform.position.z > topeEnZ)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, topeEnZ);
        }
        if (transform.position.x < -topeEnX)
        {
            transform.position = new Vector3(-topeEnX, transform.position.y, transform.position.z);
        }
        if (transform.position.x > topeEnX)
        {
            transform.position = new Vector3(topeEnX, transform.position.y, transform.position.z);
        }
    }

    public void RecibeGolpe(int golpe)
    {
        if (!muerto)
        {
            actualVida -= golpe;
            vida.value = actualVida;
        }        
    }

    public void RecibePuntos(int puntos)
    {
        score += puntos;
        scoreCount.text = "Score: " + score.ToString();
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Enemy") || col.gameObject.CompareTag("PowerUp"))
        {
            Destroy(col.gameObject);
        }
    }

    IEnumerator RecargaPartida()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
