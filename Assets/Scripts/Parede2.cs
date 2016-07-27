using UnityEngine;
using System.Collections;

public class Parede2 : MonoBehaviour {
    float speed = 2;
    float x, z,X;
    public float y;
    public GameObject parede;
    //   int ativou = 0;
    // int colidiu = 0;
    bool colidiu = false;
	// Use this for initialization
	void Start()
    {
        y = transform.position.y;
        x = transform.position.x;
        X = x;
    }
	// Update is called once per frame
	void Update () {
       
        Vector2 input = new Vector2(transform.position.x,y);
        Vector2 direction = input.normalized;
        Vector2 velocity = direction * speed;
        Vector2 moveAmount = velocity * Time.deltaTime;

        transform.Translate(moveAmount);

        if(colidiu == false)
        {
            y++;
           x = X;
        }
        else
        {
            y--;
           x = X;
        }
    }

     void OnTriggerEnter2D(Collider2D parede)
      {
          if(parede.tag == "Céu")
          {
              print("ok");
              y--;
              colidiu = true;
          }

          if(parede.tag == "Ground")
          {
              print("Colidiu com o chão");
              y++;
              colidiu = false;
          }
      }
         

}
