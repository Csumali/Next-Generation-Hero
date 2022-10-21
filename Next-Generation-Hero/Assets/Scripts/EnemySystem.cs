using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySystem : MonoBehaviour
{
    public GameObject planeSample;
    public GameObject cameraObject;
    private Camera cameras;
    private float maxX, maxY;
    private Vector3 worldCenter;
    private int enemies = 0;
    private int enemiesDestroyed = 0;
    private bool randomMode = false;
    private bool sequential = true;

    // Start is called before the first frame update
    void Start()
    {
        cameras = cameraObject.GetComponent<Camera>();
        maxX = cameras.orthographicSize * cameras.aspect; 
        maxY = cameras.orthographicSize;
        worldCenter = cameras.transform.position;

        for (int i = 0; i < 10; i++)
        {
            SpawnAnEnemy();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("e"))
        {
            //ChangeMode();
        }
        if (Input.GetKeyDown("j"))
        {
            ToggleSequential();
        }
    }

    void SpawnAnEnemy()
    {
        GameObject p = GameObject.Instantiate(planeSample) as GameObject;
        float x = Random.Range((worldCenter.x - maxX) * 0.9f, (worldCenter.x + maxX) * 0.9f);
        float y = Random.Range((worldCenter.y - maxY) * 0.9f, (worldCenter.y + maxY) * 0.9f);
        p.transform.position = new Vector3(x, y, 0f);
        enemies++;
    }

    public void Die()
    {
        enemies--;
        enemiesDestroyed++;
        SpawnAnEnemy();
    }

    public int getEnemies()
    {
        return enemies;
    }

    public int getEnemiesDestroyed()
    {
        return enemiesDestroyed;
    }

    void ChangeMode()
    {
        randomMode = !randomMode;
    }

    public bool getMode()
    {
        return randomMode;
    }

    void ToggleSequential()
    {
        sequential = !sequential;
    }

    public bool getSequential()
    {
        return sequential;
    }
}
