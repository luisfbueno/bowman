using UnityEngine;
using System.Collections;

public class SoltaBombaScript : MonoBehaviour {
    float speed = 2;
    public float x;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("space"))
        {
            print("space key was pressed");
            Vector2 input = new Vector2(x, transform.position.y);
            Vector2 direction = input.normalized;
            Vector2 velocity = direction * speed;
            Vector2 moveAmount = velocity * Time.deltaTime;

            transform.Translate(moveAmount);
            x++;
        }
	}
}
