using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthText : MonoBehaviour
{
    private HeroHealth heroHealth;
    private Text text;

    // Start is called before the first frame update
    void Start()
    {
        heroHealth = GameObject.Find("Hero").GetComponent<HeroHealth>();
        text = gameObject.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        HealthUpdate();
        ShowHealth();
    }

    void HealthUpdate()
    {
        text.text = "HP: " + heroHealth.getHealth();
    }

    void ShowHealth()
    {
        if (heroHealth.getHealthToggled())
        {
            text.enabled = true;
        } else
        {
            text.enabled = false;
        }
    }
}
