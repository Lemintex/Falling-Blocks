using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingBlock : MonoBehaviour
{
    public float minSpeed = 3.5f, maxSpeed = 7;
    // Update is called once per frame
    void Update()
    {
        float speed = Mathf.Lerp(minSpeed, maxSpeed, Difficulty.GetDifficulty());
        transform.Translate(Vector2.down * speed * Time.deltaTime); //move the block down

        if(transform.position.y + transform.localScale.y < -Camera.main.orthographicSize) //if block is off screen
        {
            Destroy(gameObject);
        }
    }
}
