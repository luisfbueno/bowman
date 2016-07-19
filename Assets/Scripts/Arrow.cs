using UnityEngine;
using System.Collections;

public class Arrow : MonoBehaviour
{

    public float standardForceMultiplier;
    public GameObject shootingPlayer;
    
    public void Shoot(Vector2 differenceBetweenPoints, float magnitudeBetweenPoints, Vector2 arrowStart)
    {
        Rigidbody2D rb = gameObject.GetComponentInChildren<Rigidbody2D>();
        rb.AddForce(differenceBetweenPoints.normalized * magnitudeBetweenPoints * standardForceMultiplier); //normal do vetor de distancia entre pontos* distancia entre pontos
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
       
        if(collision.gameObject.tag == "Head")
        {
            collision.gameObject.transform.parent.GetComponent<PlayerController>().addDamage(3);
        }

        if (collision.gameObject.tag == "Body")
        {
            collision.gameObject.transform.parent.GetComponent<PlayerController>().addDamage(2);
        }

        if (collision.gameObject.tag == "Legs")
        {
            collision.gameObject.transform.parent.GetComponent<PlayerController>().addDamage(1);
        }

        
    }
}
