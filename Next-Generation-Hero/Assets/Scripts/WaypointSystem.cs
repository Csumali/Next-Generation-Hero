using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointSystem : MonoBehaviour
{
    private bool hiding = false;

    private GameObject waypointA;
    private GameObject waypointB;
    private GameObject waypointC;
    private GameObject waypointD;
    private GameObject waypointE;
    private GameObject waypointF;

    // Start is called before the first frame update
    void Start()
    {
        waypointA = GameObject.Find("A_Walk");
        waypointB = GameObject.Find("B_Walk");
        waypointC = GameObject.Find("C_Walk");
        waypointD = GameObject.Find("D_Walk");
        waypointE = GameObject.Find("E_Walk");
        waypointF = GameObject.Find("F_Walk");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("h"))
        {
            Hide();
        }
    }

    void Hide()
    {
        waypointA.SetActive(hiding);
        waypointB.SetActive(hiding);
        waypointC.SetActive(hiding);
        waypointD.SetActive(hiding);
        waypointE.SetActive(hiding);
        waypointF.SetActive(hiding);
        hiding = !hiding;
    }

    public bool getHiding()
    {
        return hiding;
    }
}
