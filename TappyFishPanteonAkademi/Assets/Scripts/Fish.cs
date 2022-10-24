using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] private float speed;
    int angle;
    int maxAngle = 20;
    int minAngle = -60;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {

        FishSwim();
        FishRotation();



    }

    void FishSwim()
    {
        if (Input.GetMouseButtonDown(0))
        {
            rb.velocity = Vector2.zero;
            rb.velocity = new Vector2(rb.velocity.x, speed);
        }
    }

    void FishRotation()
    {
        if (rb.velocity.y > 0)
        {
            if (angle <= maxAngle)
            {
                angle = angle + 4;
            }
        }
        else if (rb.velocity.y < -3)
        {
            if (angle > minAngle)
            {
                angle = angle - 2;
            }

        }

        transform.rotation = Quaternion.Euler(0, 0, angle); // açısal dönüşü yapmak için bu kod
    }



}
