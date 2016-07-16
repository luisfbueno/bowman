using UnityEngine;
using System.Collections;

public class Arrow : MonoBehaviour
{

    public float standardForceMultiplier;
    public GameObject shootingPlayer;
    
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Shoot(Vector2 differenceBetweenPoints, float magnitudeBetweenPoints, Vector2 arrowStart)
    {
        Rigidbody2D rb = gameObject.GetComponentInChildren<Rigidbody2D>();
        rb.AddForce(differenceBetweenPoints.normalized * magnitudeBetweenPoints * standardForceMultiplier); //normal do vetor de distancia entre pontos* distancia entre pontos
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {

        PlayerController parent = collision.gameObject.transform.parent.GetComponent<PlayerController>();
       
        if(collision.gameObject.tag == "Head")
        {
            parent.addDamage(3);
        }

        if (collision.gameObject.tag == "Body")
        {
            parent.addDamage(2);
        }

        if (collision.gameObject.tag == "Legs")
        {
            parent.addDamage(1);
        }

        
    }
}
