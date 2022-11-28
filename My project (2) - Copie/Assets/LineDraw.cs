using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineDraw : MonoBehaviour
{
    SpawnObject spawnObject;
    [SerializeField] GameObject test;
    GameManager gameManager;
    LineRenderer lineRend;
    LineDraw lineDraw;
    public Vector3 pos1;
    private Vector3 pos2;
    public Vector3 HitTransform;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GetComponent<GameManager>();
        lineRend = GetComponent<LineRenderer>();
        spawnObject = GetComponent<SpawnObject>();
        lineDraw = GetComponent<LineDraw>();
    }

    Vector3 pos;
    public float offset = 0f;
    private bool TraceLine;
    public float lenght = 0;

    void Update()
    {


        GetHousePos();
        GetFinishPoint();

        DrawnLine(HitTransform,transform.position);



    }

    Vector3 GetHousePos()
    {
        if (Input.GetMouseButton(0) && TraceLine == false)
        { // if left button pressed...
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            TraceLine = true;
            if (Physics.Raycast(ray, out hit))
            {

                HitTransform = hit.transform.position;

            }

        }
        return HitTransform;
    }
    void DrawnLine(Vector3 startPoint,Vector3 FinishPoint)
    {
        if (Input.GetMouseButton(0))
        {
            
            pos1 = new Vector3(transform.position.x, 0, transform.position.z);
            pos2 = new Vector3(HitTransform.x, 0, HitTransform.z);
            lineRend.SetPosition(1, new Vector3(FinishPoint.x, -70, FinishPoint.z));
            lineRend.SetPosition(0, new Vector3(startPoint.x, -70, startPoint.z));
            TraceLine = true;
            lenght = (pos2 - pos1).magnitude;

        }
        else if (Input.GetMouseButtonUp(0))
        {
            lineRend.SetPosition(1, new Vector3(transform.position.x, 0, transform.position.z));
            lineRend.SetPosition(0, new Vector3(HitTransform.x, 0, HitTransform.z));

        }
    }
    Vector3 GetFinishPoint()
    {
        pos = Input.mousePosition;
        pos.z = offset;
        transform.position = Camera.main.ScreenToWorldPoint(pos);
        transform.position = new Vector3(transform.position.x, 0, transform.position.z);
        return transform.position;
    }
}