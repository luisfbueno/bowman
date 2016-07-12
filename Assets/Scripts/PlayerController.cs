using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{

    public GameObject arrowPrefab;
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
            startingMousePosition = GetMousePosition();
            pressed = true;
        }

        if(Input.GetMouseButtonUp(0) && pressed) //Pega a posição na qual o mouse foi solto e chama a função de soltar a flecha
        {
            finalMousePosition = GetMousePosition();
            Vector2 differenceBetweenPointsVector = startingMousePosition - finalMousePosition;
            float distanceBetweenPoints = differenceBetweenPointsVector.magnitude;
            pressed = false;
            GameObject newArrow = (GameObject)Instantiate(arrowPrefab, arrowStart, Quaternion.identity);
            newArrow.GetComponent<Arrow>().Shoot(differenceBetweenPointsVector,distanceBetweenPoints,arrowStart);
        }

    }

    Vector2 GetMousePosition () //Função para pegar a posição do mouse no atual momento e converter de pixes para posição global
    {
        return FindObjectOfType<Camera>().ScreenToWorldPoint(Input.mousePosition);
    }

}
