using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggSystem : MonoBehaviour
{
    public GameObject eggSample;
    private int numberOfEggs;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnAnEgg(Vector3 position, Vector3 up)
    {
        GameObject e = GameObject.Instantiate(eggSample) as GameObject;
        e.transform.position = position;
        e.transform.up = up;
        numberOfEggs++;
    }

    public void DecEggCount()
    {
        numberOfEggs--;
    }

    public int getEggs()
    {
        return numberOfEggs;
    }
}
