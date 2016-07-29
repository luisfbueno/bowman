using UnityEngine;
using System.Collections;

public class Caixas : MonoBehaviour
{
    public float x;
    public float y;
    public GameObject respawn;
    public GameObject respawbomba;
    float speed = 10;
    float speedb = 2;
    public float sizexbomba, sizeybomba;
    GameObject bomba;
    bool ativou = false;
    GameObject b;
    // float speed1 = 2;

    // Update is called once per frame
    void Update()
    {
        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        Vector2 direction = input.normalized;
        Vector2 velocity = direction * speed;
        Vector2 moveAmount = velocity * Time.deltaTime;

        transform.Translate(moveAmount);

        if (Input.GetKeyDown("space"))
        {
            print("space key was pressed");
            SoltaBomba();
        }
         if(ativou == true)
        {
            bomba.transform.position = new Vector2(x,y);
            Vector2 directionb = bomba.transform.position.normalized;
            Vector2 velocityb = directionb * speedb;
            Vector2 moveAmountb = velocityb * Time.deltaTime;
            bomba.transform.Translate(moveAmountb);
            x+= 0.05F;
        }
    }
   void SoltaBomba()
    {
        // Cria uma bomba 
        bomba = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        bomba.transform.position = new Vector2(x, y);
        bomba.transform.localScale += new Vector3(0.0000000006F, 0.000000006F,1);
        // Adiciona Componentes e Destruir Componentes
        bomba.AddComponent<BoxCollider2D>();
      //  bomba.AddComponent<Rigidbody2D>();
        bomba.SetActive(true);
        ativou = true;
    }

    // Faz a caixa desaparecer
    void OnTriggerEnter2D(Collider2D triggerCollider)
    {
        if (triggerCollider.tag == "Caixas")
        {
            // Desaparece com a caixa
            Destroy(triggerCollider.gameObject);
           // BoxConter++;
        }

    }


}