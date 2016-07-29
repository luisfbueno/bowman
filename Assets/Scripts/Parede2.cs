using UnityEngine;
using System.Collections;

public class Parede2 : MonoBehaviour {
    private float x, y;
    public Vector2 startPosition;
    public GameObject wall;
    public Vector2 end;
    bool colisao = false;

    // Use this for initialization
    void Start()
    {
        x = transform.position.x;
        y = transform.position.y;

    }

    // Update is called once per frame
    void Update()
    {
        // Update the wall position
        wall.transform.position = new Vector2(x, y);

        if (y >= end.y)
        {
            print("1");
            y -= 0.01F;
            colisao = true;
        }

        if (colisao == false)
        {
            y += 0.01F;
        }

        if (colisao == true)
        {
            y -= 0.01F;
        }
        if (y == startPosition.y)
        {
            print("2");
            y += 0.01F;
            colisao = false;
        }
    }

}
