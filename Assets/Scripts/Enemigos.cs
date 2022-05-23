using UnityEngine;

public class Enemigos : NPC // INHERITANCE
{ 
    public override void OnCollisionEnter(Collision col) // POLIMORPHISM
    {
        if (col.gameObject.CompareTag("Player"))
        {
            col.gameObject.GetComponent<PlayerController>().RecibeGolpe(20);
        }
    }
}
