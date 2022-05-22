using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 40f;
    private Rigidbody playerRb;
    private float topeEnZ = 8;
    private float topeEnX = 11;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        ConstrainPlayerPosition();        
    }
    void MovePlayer()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        playerRb.AddForce(Vector3.forward * speed * verticalInput);
        playerRb.AddForce(Vector3.right * speed * horizontalInput);
    }
    void ConstrainPlayerPosition()
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
    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Choca");
        }        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PowerUp"))
        {
            Destroy(other.gameObject);
        }
    }
}
