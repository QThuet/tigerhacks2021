using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite[] spriteArray;
    //if I want to have the rotate and movement independent of eachother
    //I should create a wrapper for the player object and rotate the player and not the wrapper
    public GameObject Bullet;
    public GameObject Astroid;
    public float speed = 1.5f;
    public float rotationSpeed = 20.0f;
    public float acceleration = 0;
    // Start is called before the first frame update
    void Start()
    {
        acceleration = 0;   
    }

    // Update is called once per frame
    float translation;
    private float myTime = 0.0F;
    void Update()
    {
        translation = Input.GetAxis("Vertical") * speed;
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed;
        //to make sure mytime doesn't overflow
        if (myTime < 25f)
        {
            myTime = myTime + Time.deltaTime;
        }
        //adds bounds to the board
        Vector2 pos = transform.position;
       
        if(pos.x >= 9.65)
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
        //increase speed
        if (Input.GetAxis("Vertical") == -1 || Input.GetAxis("Vertical") == 1)
        {
            acceleration += Input.GetAxis("Vertical")*0.005f; 
            spriteRenderer.sprite = spriteArray[1];
        }
        //natural deceleration
        else
        {
            spriteRenderer.sprite = spriteArray[0];
            if (acceleration != 0)
            {
                if(acceleration > 0)
                {
                    acceleration -= 0.002f;
                }
                else
                {
                    if (acceleration < 0)
                    {
                        acceleration += 0.002f;
                    }
                }
            }
            if (acceleration <= 0.001 && acceleration >= -0.001)
            {
                acceleration = 0;
            }
        }
       
        translation = (speed * acceleration) * Time.deltaTime;
        rotation *= Time.deltaTime;

        transform.Translate(0, translation, 0);
        transform.Rotate(0, 0, rotation);

        if (Input.GetButton("f") && (myTime > 0.75f))
        {
            Instantiate(Bullet, transform.position, transform.rotation);
            myTime = 0;
        }
        if (Input.GetButton("+") && myTime > 2f)
        {
            Instantiate(Astroid);
            Instantiate(Astroid);
            Instantiate(Astroid);
            Instantiate(Astroid);
            Instantiate(Astroid);
            Instantiate(Astroid);
            Instantiate(Astroid);
            Instantiate(Astroid);
            Instantiate(Astroid);
            Instantiate(Astroid);
            Instantiate(Astroid);
            Instantiate(Astroid);
            Instantiate(Astroid);
            Instantiate(Astroid);
            Instantiate(Astroid);
            myTime = 0;
        }
    }
    public float getspeed()
    {
        return translation;
    }
}
