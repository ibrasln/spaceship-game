using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    float moveSpeed = 20f;
    public static int health = 10;
    float leftTarget = -8f;
    float rightTarget = 8f;

    [SerializeField]
    GameObject missile;

    [SerializeField]
    Transform missilePosition;

    [SerializeField]
    float missileSpeed = 10f;

    GameManager gameManager;

    [SerializeField]
    AudioClip fire, death;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    void Update()
    {
        #region Movement
        float h = Input.GetAxis("Horizontal");

        transform.Translate(Vector2.right * h * moveSpeed * Time.deltaTime);
        #endregion

        #region Fire
        if (Input.GetButtonDown("Jump"))
        {
            InvokeRepeating("Fire", 0.00001f, 0.3f);
            GameObject.Find("SoundController").GetComponent<AudioSource>().PlayOneShot(fire);

        }

        if (Input.GetButtonUp("Jump"))
        {
            CancelInvoke("Fire");
        }
        #endregion

        #region Death
        if(health <= 0)
        {
            Destroy(gameObject);
            GameObject.Find("SoundController").GetComponent<AudioSource>().PlayOneShot(death);
        }
        #endregion

        Vector2 temp = transform.position;
        temp.x = Mathf.Clamp(temp.x, leftTarget, rightTarget);
        transform.position = temp;
    }

    public void Fire()
    {
        GameObject _missile = Instantiate(missile, missilePosition.position, missile.transform.rotation) as GameObject;
        _missile.GetComponent<Rigidbody2D>().velocity = new Vector2(0, missileSpeed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("EnemyMissile"))
        {
            Destroy(collision.gameObject);
            gameManager.UpdateLives(1);
        }
    }

    

}
