using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_sc : MonoBehaviour
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
    float mvSpeed = 10;
    void Move()
    {
        float xInput = Input.GetAxis("Horizontal");
        float yInput = Input.GetAxis("Vertical");

        if ((transform.position.x < -10) && (xInput < 0))
            transform.Translate(new Vector2(0, yInput) * mvSpeed * Time.deltaTime);
        else if ((transform.position.x > 10) && (xInput > 0))
            transform.Translate(new Vector2(0, yInput) * mvSpeed * Time.deltaTime);
        else if ((transform.position.y < -5) && (yInput < 0))
            transform.Translate(new Vector2(xInput, 0) * mvSpeed * Time.deltaTime);
        else if ((transform.position.y > 5) && (yInput > 0))
            transform.Translate(new Vector2(xInput, 0) * mvSpeed * Time.deltaTime);
        /*
        else if ((transform.position.x < -10) || (transform.position.x > 10))
            transform.Translate(new Vector2(0, yInput, 0) * mvSpeed * Time.deltaTime);
        else if ((transform.position.y < -10) || (transform.position.y > 10))
            transform.Translate(new Vector2(xInput, 0, 0) * mvSpeed * Time.deltaTime);
        */
        else
            transform.Translate(new Vector2(xInput, yInput) * mvSpeed * Time.deltaTime);
    }

    [SerializeField]
    GameObject BulletPrefab;
    [SerializeField]
    float fireRate = 0.5f;
    [SerializeField]
    float nextFire = 0.5f;

    [SerializeField]
    bool isTripleShotActive = false;
    [SerializeField]
    bool isShieldActive = false;
    void Fire()
    {

        if (Input.GetKeyDown(KeyCode.Space) && Time.time >= nextFire)
        {
            if (isTripleShotActive)
            {
                Instantiate(BulletPrefab, transform.position + (new Vector3(0.75f, -0.4f, 0)), Quaternion.identity);
                Instantiate(BulletPrefab, transform.position + (new Vector3(-0.75f, -0.4f, 0)), Quaternion.identity);
            }
            Instantiate(BulletPrefab, transform.position + (new Vector3(0, 0.8f, 0)), Quaternion.identity);

            nextFire = Time.time + fireRate;
        }
    }

    [SerializeField]
    int lives = 3;

    public void Damage()
    {
        if (isShieldActive)
            isShieldActive = false;
        else
        {
            lives--;

            if (lives > 0)
            {
                transform.position = new Vector2(0, 0);
            }
            else
            {
                Spawner_sc Spawner = GameObject.Find("Spawner").GetComponent<Spawner_sc>(); ;
                Spawner.stopSpawnerFunc();

                Destroy(gameObject);
            }
        }
    }

    [SerializeField]
    GameObject Shield;
    public void activateBonus(string bonus)
    {
        if (bonus == "TripleShot")
        {
            isTripleShotActive = true;
            StartCoroutine(deactivateBonus(bonus, 5));
        }
        else if (bonus == "Shield")
        {
            isShieldActive = true;
            Shield.SetActive(true);
            StartCoroutine(deactivateBonus(bonus, 10));
        }
        else if (bonus == "Speed")
        {
            mvSpeed = 15;
            StartCoroutine(deactivateBonus(bonus, 3));
        }
    }

    IEnumerator deactivateBonus(string bonus, int timeout = 5)
    {
        yield return new WaitForSeconds(timeout);

        if (bonus == "TripleShot")
            isTripleShotActive = false;
        else if (bonus == "Shield")
        {
            isShieldActive = false;
            Shield.SetActive(false);
        }
        else if (bonus == "Speed")
            mvSpeed = 10;
    }
}