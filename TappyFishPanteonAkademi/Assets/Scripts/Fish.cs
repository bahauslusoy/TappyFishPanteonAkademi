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
    public Score score;

    bool touchedGround;

    public GameManager gameManager;
    public Sprite fishDied;
    SpriteRenderer sp;
    Animator anim;



    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sp = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {

        FishSwim();




    }

    private void FixedUpdate()
    {
        FishRotation();
    }

    void FishSwim()
    {
        if (Input.GetMouseButtonDown(0) && GameManager.gameOver == false)
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
        if (touchedGround == false)
        {
            transform.rotation = Quaternion.Euler(0, 0, angle); // açısal dönüşü yapmak için bu kod
        }

    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Obstacle"))
        {

            Debug.Log("AAA");
            score.Scored();
        }
        else if (other.CompareTag("Column"))
        {
            gameManager.GameOver();
            
        }
    }

    private void OnCollisionEnter2D(Collision2D other) // COLLISION TRIGGER ARASINDAKİ FARK gameobject yazıyoruz istrigger tikli değil collisionda
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            if (GameManager.gameOver == false)
            {
                gameManager.GameOver();
                GameOver();
            }

            else
            {
                GameOver();
            }
        }

    }

    void GameOver()
    {
        touchedGround = true;
        transform.rotation = Quaternion.Euler(0, 0, -90);
        sp.sprite = fishDied;
        anim.enabled = false;
    }



}
