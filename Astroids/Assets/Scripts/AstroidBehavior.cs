using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstroidBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Vector3 pos = transform.position;

        float rotation = Random.value*360;
        transform.Rotate(0, 0, rotation);

        while (pos.x < 0.3 && pos.x > -0.3 || pos == transform.position)
        {
            pos.x = ((float)Random.value - 0.5f) * 19f;
            pos.y = ((float)Random.value - 0.5f) * 10.6f;
        }
        transform.position = pos;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 pos = transform.position;

        if (pos.x >= 9.65)
        {
            pos.x = -9.6f;
            transform.position = pos;
        }
        if (pos.x <= -9.65)
        {
            pos.x = 9.6f;
            transform.position = pos;
        }
        if (pos.y >= 5.35)
        {
            pos.y = -5.3f;
            transform.position = pos;
        }
        if (pos.y <= -5.35)
        {
            pos.y = 5.3f;
            transform.position = pos;
        }

        transform.Translate(0, 0.015f, 0);
    }
}
