using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    private EnemySystem enemySystem;
    private HeroMovement hero;
    private int health = 4;
    private float speed = 20f;
    private float rotateSpeed = 100f;
    private float changeDirCooldown = 2f;
    private float nextChange;
    private float direction;

    private GameObject[] waypoints;
    int current = 0;
    private float WPradius = 20f;
    private GameObject waypointA;
    private GameObject waypointB;
    private GameObject waypointC;
    private GameObject waypointD;
    private GameObject waypointE;
    private GameObject waypointF;
    private Rigidbody2D rb2d;

    // Start is called before the first frame update
    void Start()
    {
        enemySystem = GameObject.Find("EnemySystem").GetComponent<EnemySystem>();
        hero = GameObject.Find("Hero").GetComponent<HeroMovement>();
        nextChange = Time.time;

        waypointA = GameObject.Find("A_Walk");
        waypointB = GameObject.Find("B_Walk");
        waypointC = GameObject.Find("C_Walk");
        waypointD = GameObject.Find("D_Walk");
        waypointE = GameObject.Find("E_Walk");
        waypointF = GameObject.Find("F_Walk");
        waypoints = new GameObject[]{waypointA, waypointB, waypointC, waypointD, waypointE, waypointF};
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (enemySystem.getMode())
        {
            randomMovement();
        } else
        {
            Patrol();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Hero")
        {
            DestroyThisEnemy();
            hero.Touch();
        }
        else if (collision.gameObject.tag == "Egg")
        {
            health--;
            if (health > 0)
            {
                SpriteRenderer renderer = gameObject.GetComponent<SpriteRenderer>();
                Color tempColor = new Color(renderer.color.r, renderer.color.g, renderer.color.b, renderer.color.a * 0.8f);
                renderer.color = tempColor;
            }
            else
            {
                DestroyThisEnemy();
            }
        }
        else if (collision.gameObject.tag == "Missile")
        {
            DestroyThisEnemy();
        }
        else if (collision.gameObject.tag == "VerEdge")
        {
            transform.RotateAround(transform.position, Vector3.up, 180f);
        } 
        else if (collision.gameObject.tag == "HorEdge")
        {
            transform.RotateAround(transform.position, Vector3.right, 180f);
        }
    }

    private void DestroyThisEnemy()
    {
        if (gameObject.activeSelf)
        {
            enemySystem.Die();
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }
    private void randomMovement()
    {
        transform.position += transform.up * (speed * Time.smoothDeltaTime);
        if (Time.time > nextChange)
        {
            direction = Random.Range(-1f, 1f);
            nextChange = Time.time + changeDirCooldown;
        }
        transform.Rotate(Vector3.forward, -1f * direction * (rotateSpeed * Time.smoothDeltaTime));
    }
    void Patrol()
    {
        if (Vector2.Distance(waypoints[current].transform.position, transform.position) < WPradius)
        {
            if (enemySystem.getSequential())
            {
                current++;
                if (current >= waypoints.Length)
                {
                    current = 0;
                }
            } 
            else
            {
                int rand = current;
                while (rand == current)
                {
                    rand = Random.Range(0, waypoints.Length);
                }
                current = rand;
            }
        }
        

        Vector2 lookDirection = new Vector2(waypoints[current].transform.position.x, waypoints[current].transform.position.y) - new Vector2(transform.position.x, transform.position.y);
        float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg - 90f;
        Quaternion qTo = Quaternion.Euler(new Vector3(0, 0, angle));
        transform.rotation = Quaternion.RotateTowards(transform.rotation, qTo, rotateSpeed * Time.deltaTime);
        transform.position += transform.up * (speed * Time.smoothDeltaTime);
    }
}
