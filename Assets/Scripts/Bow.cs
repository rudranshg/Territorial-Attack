using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : MonoBehaviour//script name is Bow and is attached to bow gameelement
{//circle prefab is used to show points
    public Vector2 Direction;
    private float force;
    public GameObject PointPrefab;
    public GameObject[] Points;
    private int arraysize=40;
    public int numberOfPoints;
    public Shoot shoot;
    public GameObject extraPoint;

    void Start() /*No of points*/
    {
        Points = new GameObject[arraysize];
        for (int i = 0; i < numberOfPoints; i++)
        {
            Points[i] = Instantiate(PointPrefab, transform.position, Quaternion.identity);
        }

    }

    // For mouse positioning
    void Update()

    {
        Vector2 MousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 bowPos = transform.position;
        Direction = MousePos - bowPos;
        faceMouse();
        for (int i = 0; i < numberOfPoints; i++)
        {
            Points[i].transform.position = PointPosition(i * 0.05f);
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
        for (int i = 0; i < arraysize; i++)
        {
            Points[i] = Instantiate(PointPrefab, transform.position, Quaternion.identity);
        }
        numberOfPoints=40;
    }
    public void retain()
    {     numberOfPoints=5;
        for (int i = 0; i < numberOfPoints; i++)
        {
            Points[i] = Instantiate(PointPrefab, transform.position, Quaternion.identity);
           
        }
        
    }
}
