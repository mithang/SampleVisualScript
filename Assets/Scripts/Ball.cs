using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody2D rb;
    public float bounceForce;
    private bool gameStarted;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameStarted)
        {
            if (Input.anyKeyDown)
            {
                StartBounce();
                gameStarted = true;
                GameManager.instance.GameStart();
            }
        }
        
    }

    //Tạo ra hướng đi khi nảy ball được nảy lên
    void StartBounce()
    {
        Vector2 randomDirection = new Vector2(Random.Range(-1,1),1);
        rb.AddForce(randomDirection*bounceForce, ForceMode2D.Impulse);
    }


    //Xử lý va chạm của ball với paddle và fallcheck
    private void OnCollisionEnter2D(Collision2D collision)
    {
       
        if (collision.gameObject.tag == "FallCheck")
        {
            GameManager.instance.Restart();
        }else if (collision.gameObject.tag == "Paddle")
        {
            GameManager.instance.ScoreUp();
        }
    }
}
