using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : MonoBehaviour//script name is Bow and is attached to bow gameelement
{//circle prefab is used to show points
    public Vector2 Direction;
    private float force;

    public GameObject PointPrefab;
    public GameObject[] Points;
    public GameObject extraPoint;
    public GameObject HammerButton;

    private int arraysize=40;
    public int numberOfPoints;

    public bool tracer=false;

    public Shoot shoot;

    public DisableEnable enable;

    void Start() /*No of points*/
    {
        Points = new GameObject[arraysize];
        for (int i = 0; i < numberOfPoints; i++)
        {
            Points[i] = Instantiate(PointPrefab, transform.position, Quaternion.identity);
            Points[i].SetActive(false);
        }

    }

    // For mouse positioning
    void Update()

    {
        if((enable.appears1 || enable.appears2 || enable.appears3 || HammerButton.activeSelf )&& !tracer)
        {
                for (int i = 0; i < 5; i++)
                {
                    Points[i].SetActive(true);
                }
        }
        else if ((enable.appears1 || enable.appears2 || enable.appears3 || HammerButton.activeSelf) && tracer)
        {
            for (int i = 0; i < 40; i++)
            {
                Points[i].SetActive(true);
            }
        }
        else 
        {
            Inactive();
        }
        Vector2 MousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 bowPos = transform.position;
        Direction = MousePos - bowPos;
        if(Input.GetAxis("Fire3") !=0)
        {
            faceMouse();
            for (int i = 0; i < numberOfPoints; i++)
            {
                Points[i].transform.position = PointPosition(i * 0.05f);
            }
        }       
    }
    void faceMouse()
    {
        transform.right = Direction;

    }
    Vector2 PointPosition(float t)
    {   
        force=(float) (shoot.LaunchForce/71.5);
        Vector2 currentPointPos = (Vector2)transform.position + (Direction.normalized * force * t) + 0.5f * Physics2D.gravity * (t * t);
        return currentPointPos;
    }
    public void Tracer()
    {
        tracer = true;
        Inactive();
        for (int i = 0; i < arraysize; i++)
        {
            Points[i] = Instantiate(PointPrefab, transform.position, Quaternion.identity);
        }
       numberOfPoints=40;
    }

    public void Inactive()
    {
        for (int i = 0; i < numberOfPoints; i++)
        {
            Points[i].SetActive(false);
        }
    }
}
