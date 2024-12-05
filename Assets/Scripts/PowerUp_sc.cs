using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp_sc : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    [SerializeField]
    float mvSpeed = 3;
    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        transform.Translate(Vector2.down * mvSpeed * Time.deltaTime);

        if (transform.position.y < -6)
            Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Player_sc Player = other.GetComponent<Player_sc>();

            Player.activateBonus(this.gameObject.tag);

            Destroy(this.gameObject);
        }
    }
}
