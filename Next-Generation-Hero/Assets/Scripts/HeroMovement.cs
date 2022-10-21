using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroMovement : MonoBehaviour
{
    private bool mouseModeActive;
    private float speed;
    private float rotateSpeed = 45f;
    private int enemiesTouched = 0;
    private HeroHealth heroHealth;

    // Start is called before the first frame update
    void Start()
    {
        mouseModeActive = true;
        speed = 20f;
        heroHealth = gameObject.GetComponent<HeroHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("m"))
        {
            ChangeMode();
        }

        if (mouseModeActive) MouseMode();
        else KeyboardMode();

        UpdateRotation();
    }

    void ChangeMode()
    {
        mouseModeActive = !mouseModeActive;
    }

    void MouseMode()
    {
        Vector3 p = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        p.z = 0f;
        transform.position = p;
    }

    void KeyboardMode()
    {
        speed += Input.GetAxis("Vertical") * 0.25f;
        if (speed > 200f) speed = 150f;
        if (speed < 0f) speed = 0f;
        transform.position += transform.up * (speed * Time.smoothDeltaTime);
        
    }

    void UpdateRotation()
    {
        transform.Rotate(Vector3.forward, -1f * Input.GetAxis("Horizontal") * (rotateSpeed * Time.smoothDeltaTime));
    }

    public void Touch()
    {
        enemiesTouched++;
        heroHealth.TakeDamage();
    }

    public int getTouched()
    {
        return enemiesTouched;
    }

    public bool getMode()
    {
        return mouseModeActive;
    }
}
