using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointBehavior : MonoBehaviour
{
    private int health = 4;
    private Vector3 initialPos;

    // Start is called before the first frame update
    void Start()
    {
        initialPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Egg")
        {
            health--;
            if (health > 0)
            {
                SpriteRenderer renderer = gameObject.GetComponent<SpriteRenderer>();
                Color tempColor = new Color(renderer.color.r, renderer.color.g, renderer.color.b, renderer.color.a - 0.25f);
                renderer.color = tempColor;
            }
            else
            {
                Respawn();
            }
        }
    }

    private void Respawn()
    {
        health = 4;
        SpriteRenderer renderer = gameObject.GetComponent<SpriteRenderer>();
        Color tempColor = new Color(renderer.color.r, renderer.color.g, renderer.color.b, 1f);
        renderer.color = tempColor;

        float randomX = Random.Range(-15f, 15f);
        float randomY = Random.Range(-15f, 15f);
        Vector3 newPos = new Vector3(initialPos.x + randomX, initialPos.y + randomY, transform.position.z);
        transform.position = newPos;
    }
}
