using UnityEngine;
using System.Collections;

public class Debbuger : MonoBehaviour {

    Vector2 movement;

	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        transform.Translate(movement * 5 * Time.deltaTime);

	}
}
