using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    float speed;
    void Start()
    {
        PlayerControl pc = GameObject.Find("Player").GetComponent<PlayerControl>();
        speed = pc.getspeed();
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
        transform.Translate(0, speed+0.02f, 0);
        Destroy(gameObject, 5);
    }
}
