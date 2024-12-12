using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Asteroid_sc : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Rotate();
    }

    [SerializeField] float rtSpeed = 15;
    void Rotate()
    {
        transform.Rotate(Vector3.forward * rtSpeed * Time.deltaTime);
    }

    [SerializeField] Spawner_sc Spawner;
    [SerializeField] GameObject ExplosionPrefab;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Bullet")
        {
            Destroy(other.gameObject);

            Destroy(Instantiate(ExplosionPrefab, transform.position, Quaternion.identity), 2.5f);

            Spawner = GameObject.Find("Spawner").GetComponent<Spawner_sc>();
            Spawner.Spawn();

            Destroy(gameObject);
        }
        else if (other.tag == "Player")
        {
            /*Player_sc Player = other.GetComponent<Player_sc>();
            Player.Damage();

			anim.SetTrigger("OnEnemyDeath");
            xMvSpeed = 0;
            yMvSpeed = 0;
            Destroy(gameObject, 2.5f);*/
        }
    }

}
