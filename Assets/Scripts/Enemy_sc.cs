using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_sc : MonoBehaviour
{
    Player_sc Player;
    void Start()
    {
        Player = GameObject.Find("Player").GetComponent<Player_sc>();

        if (Player == null)
            Debug.LogError("Player is NULL");
    }

    [SerializeField] float mvSpeed = 1;

    void Update()
    {
        Move();
    }

    void Move()
    {
        transform.Translate(Vector2.down * mvSpeed * Time.deltaTime);

        if (transform.position.y < -6)
            // Respawn();
            Destroy(gameObject);

        // if (transform.position.y < 0)
        //     Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Bullet")
        {
            Destroy(other.gameObject);
            // Respawn();

            if (Player != null)
                Player.UpdateScore(100);

            Destroy(gameObject);
        }
        else if (other.tag == "Player")
        {
            Player_sc Player = other.GetComponent<Player_sc>();
            Player.Damage();
            // Respawn();
            Destroy(gameObject);
        }
    }

    void Respawn()
    {
        transform.position = new Vector2(Random.Range(-10, 10), 8);
    }
}