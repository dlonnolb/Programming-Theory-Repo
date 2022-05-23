using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    [SerializeField] float speed = 40.0f;
    private float zDestroy = -10.0f;
    //private int puntos = 20;
    private Rigidbody enemyRb;

    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        enemyRb.AddForce(Vector3.forward * -speed);

        if (transform.position.z < zDestroy)
        {
            Destroy(gameObject);
        }
    }
    public virtual void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            
        }
    }
}
