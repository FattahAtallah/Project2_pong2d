using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float speed = 5.0f;
    public Transform ball;

    // Update is called once per frame
    void Update()
    {
        // Move towards the ball's y position
        float targetY = Mathf.Clamp(ball.position.y, -3f, 3f);
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, targetY, transform.position.z), speed * Time.deltaTime);
    }
}