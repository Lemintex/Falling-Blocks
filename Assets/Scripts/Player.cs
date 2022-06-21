using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public float speed = 9;
    public event System.Action OnPlayerDeath;
    float halfScreenWidth;
    // Start is called before the first frame update
    void Start()
    {
        float halfPlayerWidth = transform.localScale.x / 2f;
        halfScreenWidth = Camera.main.aspect * Camera.main.orthographicSize + halfPlayerWidth;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), 0);
        Vector2 velocity = input * speed;
        Vector2 distance = velocity * Time.deltaTime;
        transform.Translate(distance);
        if(transform.position.x < -halfScreenWidth)
        {
            transform.position = new Vector2(halfScreenWidth, transform.position.y);
        }
        else if (transform.position.x > halfScreenWidth)
        {
            transform.position = new Vector2(-halfScreenWidth, transform.position.y);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Falling Block"))
        {
            Destroy(gameObject);
            if(OnPlayerDeath != null)
            {
                OnPlayerDeath();
            }
        }
    }
}
