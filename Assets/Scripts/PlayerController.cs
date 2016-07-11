using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{

    public GameObject arrowPrefab;
    public float standardForceMultiplier;
    Vector2 arrowStart;
    Vector2 startingMousePosition;
    Vector2 finalMousePosition;
    bool pressed;

    void Start()
    {
        arrowStart = new Vector2(transform.position.x + 1, transform.position.y + 1); //Precisa implementar metodo de calculo para maior precisão
    }

    void Update()
    {

        if (Input.GetMouseButtonDown(0)) //Pega a posição do primeiro click do mouse
        {
            Camera gameCamera = FindObjectOfType<Camera>();
            startingMousePosition = GetMousePosition();
            pressed = true;
        }

        if(Input.GetMouseButtonUp(0) && pressed) //Pega a posição na qual o mouse foi solto e chama a função de soltar a flecha
        {
            finalMousePosition = GetMousePosition();
            Vector2 differenceBetweenPointsVector = startingMousePosition - finalMousePosition;
            float distanceBetweenPoints = differenceBetweenPointsVector.magnitude;
            pressed = false;
            createArrow(differenceBetweenPointsVector, distanceBetweenPoints);
        }

    }

    void createArrow(Vector2 differenceBetweenPoints,float magnitudeBetweenPoints)
    {
        GameObject newArrow = (GameObject)Instantiate(arrowPrefab, arrowStart, Quaternion.identity);
        Rigidbody2D rb = newArrow.GetComponent<Rigidbody2D>();
        rb.AddForce(differenceBetweenPoints.normalized * magnitudeBetweenPoints * standardForceMultiplier); //normal do vetor de distancia entre pontos* distancia entre pontos
    }

    Vector2 GetMousePosition () //Função para pegar a posição do mouse no atual momento e converter de pixes para posição global
    {
        Camera gameCamera = FindObjectOfType<Camera>();
        return gameCamera.ScreenToWorldPoint(Input.mousePosition);
    }

}
