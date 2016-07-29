using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{

    public GameObject arrowPrefab;
    Vector2 arrowStart;
    Vector2 startingMousePosition;
    Vector2 finalMousePosition;
    Vector2 currentMousePosition;
    private bool pressed;
    int health;
    public float player2AngleFixer;

    void Start()
    {
        if(gameObject.tag == "Player 1") //condições para determinar a posição inicial de lançamento da flecha dependendo do player
            arrowStart = new Vector2(transform.position.x + 1.5f, transform.position.y + 1); 
        else if (gameObject.tag == "Player 2")
            arrowStart = new Vector2(transform.position.x - 1.5f, transform.position.y + 1);

        health = 5; //Determina vida inicial do Player para 5
    }

    void Update()
    {

        if (Input.GetMouseButtonDown(0)) //Pega a posição do primeiro click do mouse
        {
            startingMousePosition = GetMousePosition();
            pressed = true; //variável a ser usada para desenhar a linha de mira
        }

        if (pressed) //se estiver sendo pressionado, salva a posição atual do mouse para usar
        {
            currentMousePosition = GetMousePosition();
        }


        if(Input.GetMouseButtonUp(0) && pressed) //Pega a posição na qual o mouse foi solto e chama a função de soltar a flecha
        {
            finalMousePosition = GetMousePosition(); //pega a posição final do mouse
            Vector2 differenceBetweenPointsVector = startingMousePosition - finalMousePosition; //calcula o vetor da diferença entre os dois ponts
            float distanceBetweenPoints = differenceBetweenPointsVector.magnitude; //guarda o módulo do vetor (magnitude)
            pressed = false; //variável a ser usada para desenhar a linha de mira

            float angle = 0;
                
            if(gameObject.transform.tag == "Player 1")
                angle = Vector3.Angle(new Vector2(1,0), differenceBetweenPointsVector);
            else if (gameObject.transform.tag == "Player 2")
                angle = Vector3.Angle(new Vector2(1, 0), differenceBetweenPointsVector) + player2AngleFixer;

            if (differenceBetweenPointsVector.y < 0) //se o vetor normal for abaixo do eixo y, inverter o angulo pois Vector3.angle so da o valor positivo
            {
                angle = -angle;
            }

            GameObject newArrow = (GameObject)Instantiate(arrowPrefab, arrowStart, Quaternion.Euler(0,0,angle)); //Instancia flecha
            newArrow.GetComponent<Arrow>().Shoot(differenceBetweenPointsVector,distanceBetweenPoints,arrowStart); //Adiciona força à flecha
        }

    }

    Vector2 GetMousePosition () //Função para pegar a posição do mouse no atual momento e converter de pixels para posição global
    {
        return FindObjectOfType<Camera>().ScreenToWorldPoint(Input.mousePosition);
    }

    public void addDamage (int damage)
    {
        this.health -= damage;

        if(this.health <= 0)
        {
            Destroy(this.gameObject);
        }
    } //função para causar dano ao player e destruir caso a vida chegue a zero

    public bool getPressedBool ()
    {
        return pressed;
    } //retorna variavel boolean pressed

    public Vector2 getStartingMouseVector()
    {
        return startingMousePosition;
    } //retorna vetor de posição inicial do mouse

    public Vector2 getCurrentMouseVector()
    {
        return currentMousePosition;
    } //retorna vetor de posição atual do mouse
}
