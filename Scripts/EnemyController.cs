using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    int health = 5;
    float missilesPerSecond = 0.7f;
    [SerializeField]
    GameObject missile;

    [SerializeField]
    Transform missilePos;

    [SerializeField]
    float missileSpeed = -9f;

    GameManager gameManager;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
            gameManager.UpdateScores(25);

        }

        // Random.value: It returns a number between 0 and 1
        float firePossibility = Time.deltaTime * missilesPerSecond;
        if (Random.value <= firePossibility)
        { 
            Invoke("Fire", 1.5f);
        }

    }

    public void Fire()
    {
        GameObject _missile = Instantiate(missile, missilePos.position, missile.transform.rotation) as GameObject;
        _missile.GetComponent<Rigidbody2D>().velocity = new Vector2(0, missileSpeed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Missile"))
        {
            Destroy(collision.gameObject);
            health--;
        }
    }

}
