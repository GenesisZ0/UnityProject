using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sdsf : MonoBehaviour
{
    [SerializeField] GameObject test;
    LineRenderer lineRend;
    line li;
    // Start is called before the first frame update
    void Start()
    {
        lineRend = GetComponent<LineRenderer>();
        li = FindObjectOfType<line>();

    }

    Vector3 pos;
    public float offset = 0f;


    void Update()
    {

        if (Input.GetMouseButton(0))
        {
            pos = Input.mousePosition;
            pos.z = offset;
            transform.position = Camera.main.ScreenToWorldPoint(pos);
            transform.position = new Vector3(transform.position.x, 0, transform.position.z);
            lineRend.SetPosition(1, new Vector3(transform.position.x, 0, transform.position.z));
            lineRend.SetPosition(0, new Vector3(li.transform.position.x, 0, li.transform.position.z));
        }
        else
        {
            print("test");
        }









    }
}

