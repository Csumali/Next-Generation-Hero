using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Travel();
    }

    void Travel()
    {
        transform.position += transform.up * (80f * Time.smoothDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name != "Hero" && collision.gameObject.tag != "Egg")
            DestroyThisMissile();
    }

    private void OnBecameInvisible()
    {
        DestroyThisMissile();
    }

    private void DestroyThisMissile()
    {
        if (gameObject.activeSelf)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }
}
