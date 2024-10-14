using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script : MonoBehaviour
{
    void Start()
    {
        Debug.Log("Started!");
    }

    void Update()
    {
        Move();

        Fire();
    }

    [SerializeField]
    float mvSpeed = 5;
    void Move()
    {
        float xInput = Input.GetAxis("Horizontal");
        float yInput = Input.GetAxis("Vertical");

        if ((transform.position.x < -10) && (xInput < 0))
            transform.Translate(new Vector3(0, yInput, 0) * mvSpeed * Time.deltaTime);
        else if ((transform.position.x > 10) && (xInput > 0))
            transform.Translate(new Vector3(0, yInput, 0) * mvSpeed * Time.deltaTime);
        else if ((transform.position.y < -10) && (yInput < 0))
            transform.Translate(new Vector3(xInput, 0, 0) * mvSpeed * Time.deltaTime);
        else if ((transform.position.y > 10) && (yInput > 0))
            transform.Translate(new Vector3(xInput, 0, 0) * mvSpeed * Time.deltaTime);
        /*
        else if ((transform.position.x < -10) || (transform.position.x > 10))
            transform.Translate(new Vector3(0, yInput, 0) * mvSpeed * Time.deltaTime);
        else if ((transform.position.y < -10) || (transform.position.y > 10))
            transform.Translate(new Vector3(xInput, 0, 0) * mvSpeed * Time.deltaTime);
        */
        else
            transform.Translate(new Vector3(xInput, yInput, 0) * mvSpeed * Time.deltaTime);
    }

    [SerializeField]
    GameObject BulletPrefab;
    [SerializeField]
    float fireRate = 0.5f;
    [SerializeField]
    float nextFire = 0.5f;
    void Fire()
    {

        if (Input.GetKeyDown(KeyCode.Space) && Time.time >= nextFire)
        {
            // Instantiate(BulletPrefab, transform.position, Quaternion.identity);
            Instantiate(BulletPrefab, transform.position + (new Vector3(0, 1, 0)), Quaternion.identity);
            nextFire = Time.time + fireRate;
        }
    }
}