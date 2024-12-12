using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy_sc : MonoBehaviour
{
    Player_sc Player;
    Animator anim;
    void Start()
    {
        Player = GameObject.Find("Player").GetComponent<Player_sc>();
        anim = GetComponent<Animator>();

        if (Player == null)
            Debug.LogError("Player is NULL");

		if(anim == null)
			Debug.LogError("anim is NULL");
    }

    [SerializeField] float xMvSpeed = 0;
    [SerializeField] float yMvSpeed = 1;

    void Update()
    {
        MoveY();
        MoveX();
    }

    void MoveY()
    {
        transform.Translate(Vector2.down * yMvSpeed * Time.deltaTime);

        if (transform.position.y < -6)
            Destroy(gameObject);
    }

    void MoveX()
    {
        if (transform.position.x < -10 || transform.position.x > 10)
            xMvSpeed *= -1;

        transform.Translate(Vector2.right * xMvSpeed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Bullet")
        {
            Destroy(other.gameObject);
            // Respawn();

            switch (xMvSpeed)
            {
                case 0:
                    Player.UpdateScore(10);
                    break;
                case -1:
                case 1:
                    Player.UpdateScore(20);
                    break;
                case -2:
                case 2:
                    Player.UpdateScore(30);
                    break;
                default:
                    break;
            }

			anim.SetTrigger("OnEnemyDeath");
            xMvSpeed = 0;
            yMvSpeed = 0;
            Destroy(gameObject, 2.5f);
        }
        else if (other.tag == "Player")
        {
            Player_sc Player = other.GetComponent<Player_sc>();
            Player.Damage();

			anim.SetTrigger("OnEnemyDeath");
            xMvSpeed = 0;
            yMvSpeed = 0;
            Destroy(gameObject, 2.5f);
        }
    }

    void Respawn()
    {
        transform.position = new Vector2(Random.Range(-10, 10), 8);
    }

    public void setXSpeed(float speed)
    {
        xMvSpeed = speed;
    }
}
