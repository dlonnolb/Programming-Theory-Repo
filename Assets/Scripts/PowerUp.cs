using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : NPC // Inheritance
{
    public override void OnCollisionEnter(Collision col) // Polimorphism
    {
        if (col.gameObject.CompareTag("Player"))
        {
            col.gameObject.GetComponent<PlayerController>().Puntuacion += 20;
        }
    }
}
