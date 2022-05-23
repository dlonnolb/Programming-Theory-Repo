using UnityEngine;

public class PowerUp : NPC // INHERITANCE
{
    public override void OnCollisionEnter(Collision col) // POLIMORPHISM
    {
        if (col.gameObject.CompareTag("Player"))
        {
            col.gameObject.GetComponent<PlayerController>().RecibePuntos(20);
        }
    }
}
