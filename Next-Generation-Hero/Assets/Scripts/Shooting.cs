using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject eggSystemObject;
    public GameObject missileSample;
    private EggSystem eggSystem;
    private float cooldown = 0.2f;
    private float nextShot;
    private float missileCooldown = 5f;
    private float nextMissile;

    // Start is called before the first frame update
    void Start()
    {
        eggSystem = eggSystemObject.GetComponent<EggSystem>();
        nextShot = Time.time;
        nextMissile = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("space"))
        {
            Shoot();
        }
        if (Input.GetKey("c"))
        {
            Missile();
        }
    }

    void Shoot()
    {
        if (Time.time >= nextShot)
        {
            eggSystem.SpawnAnEgg(transform.position, transform.up);
            nextShot = Time.time + cooldown;
        }
    }

    void Missile()
    {
        if (Time.time >= nextMissile)
        {
            GameObject m = GameObject.Instantiate(missileSample) as GameObject;
            m.transform.position = gameObject.transform.position;
            m.transform.up = gameObject.transform.up;
            nextMissile = Time.time + missileCooldown;
        }
    }

    public float getNextMissile()
    {
        return nextMissile;
    }
}
