using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroHealth : MonoBehaviour
{
    private int health = 5;
    private bool healthToggled = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("h"))
        {
            ToggleHealth();
        }
        CheckHealth();
    }

    void ToggleHealth()
    {
        healthToggled = !healthToggled;
    }

    public void TakeDamage()
    {
        if (healthToggled)
        {
            health--;
        }
    }

    void CheckHealth()
    {
        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        if (gameObject.activeSelf)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }

    public int getHealth()
    {
        return health;
    }

    public bool getHealthToggled()
    {
        return healthToggled;
    }
}
