using UnityEngine;
using System.Collections;

public class Arrow : MonoBehaviour
{

    public float standardForceMultiplier;
    public GameObject shootingPlayer;
    float visibleScreen;

    void Start()
    {
        visibleScreen = -Camera.main.orthographicSize - transform.localScale.x;
    }
 
   void Update ()
    {

    }
    
    public void Shoot(Vector2 differenceBetweenPoints, float magnitudeBetweenPoints, Vector2 arrowStart)
    {
        Rigidbody2D rb = gameObject.GetComponent<Rigidbody2D>();
        rb.AddForce(differenceBetweenPoints.normalized * magnitudeBetweenPoints * standardForceMultiplier); //normal do vetor de distancia entre pontos* distancia entre pontos
        FindObjectOfType<GameManager>().GetComponent<GameManager>().AddTurn();
    }

}
