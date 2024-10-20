using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_sc : MonoBehaviour
{
    void Start()
    {
        //
    }

    [SerializeField]
    float mvSpeed = 5;
    void Update()
    {
        transform.Translate(Vector3.up * mvSpeed * Time.deltaTime);

        if (transform.position.y > 8)
            Destroy(gameObject);
    }

    // void OnTriggerEnter(Collider other)
    // {
    //     if (other.tag == "Enemy")
    //         Destroy(gameObject);

    // }
}