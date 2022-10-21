using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggBehavior : MonoBehaviour
{
    private EggSystem eggSystem;

    private float speed = 40f;

    // Start is called before the first frame update
    void Start()
    {
        eggSystem = GameObject.Find("EggSystem").GetComponent<EggSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        Travel();
    }

    void Travel()
    {
        transform.position += transform.up * (speed * Time.smoothDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name != "Hero")
            DestroyThisEgg();
    }

    private void OnBecameInvisible()
    {
        DestroyThisEgg();
    }

    private void DestroyThisEgg()
    {
        if (gameObject.activeSelf)
        {
            eggSystem.DecEggCount();
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }
}
