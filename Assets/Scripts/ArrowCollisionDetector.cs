using UnityEngine;
using System.Collections;

public class ArrowCollisionDetector : MonoBehaviour
{

    public float standardForceMultiplier;
    public GameObject shootingPlayer;
    float visibleScreen;

    public void OnCollisionEnter2D(Collision2D collision)
    {
       
        if(collision.gameObject.tag == "Head")
        {
            collision.gameObject.transform.parent.GetComponent<PlayerController>().addDamage(3);
            print("Head");
        }

        if (collision.gameObject.tag == "Body")
        {
            collision.gameObject.transform.parent.GetComponent<PlayerController>().addDamage(2);
            print("Body");
        }

        if (collision.gameObject.tag == "Legs")
        {
            collision.gameObject.transform.parent.GetComponent<PlayerController>().addDamage(1);
            print("Legs");
        }

    }

}
