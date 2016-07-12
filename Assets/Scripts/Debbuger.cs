using UnityEngine;
using System.Collections;

public class Debbuger : MonoBehaviour
{

    Vector2 movement;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        transform.Translate(movement * 5 * Time.deltaTime);

    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Head")
        {
            print("Head");
        }

        if (collision.gameObject.tag == "Body")
        {
            print("Body");
        }

        if (collision.gameObject.tag == "Legs")
        {
            print("Legs");
        }
    }
}
