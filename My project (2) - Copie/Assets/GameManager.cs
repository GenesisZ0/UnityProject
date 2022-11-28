using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject Line;
    GameManager manager;
    public Vector3 HitTransform;
    private GameObject lineclone;
    private GameObject reference;
    LineDraw lineDrawScript;
    Route route;
    public house Stock;
    public house Actual;
    [SerializeField] bool Link;
    public float Multiplicateur = 1;
    private BUTTONSCRIPT bUTTONSCRIPT;
    public bool DestroyLine = false;
    public List<GameObject> ListLine;
    public int GoldNeed;

    public bool TraceLine = false;
    public float Gold;
    private house ac;

    // Start is called before the first frame update
    void Start()
    {
        route = GetComponent<Route>();
        bUTTONSCRIPT = FindObjectOfType<BUTTONSCRIPT>();
        manager = GetComponent<GameManager>();


    }

    // Update is called once per frame
    void Update()
    {

        StockHouse();
        ActualHouse();
        SpawnLine();
   



    }

    void SpawnLine()
    {
        if (Input.GetMouseButtonDown(0))
        { // if left button pressed...
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit) && TraceLine == false)
            {
                house house;
                house = hit.transform.gameObject.GetComponent<house>();

                if (house.line1 && house.line2)
                {
                    print("nop");
                }
                else
                {
                    lineclone = Instantiate(Line, hit.transform);
                    ListLine.Add(lineclone);    
                    lineDrawScript = lineclone.GetComponent<LineDraw>();
                    TraceLine = true;


                }

            }

        }
        else if (Input.GetMouseButtonUp(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                house house;
                house = FindObjectOfType<house>();
                ac = hit.transform.gameObject.GetComponent<house>();


                if (ac.link == true && TraceLine ==true)
                {
                    print("reacttte");
                   
                    lineclone.SetActive(false);
                    TraceLine = false;
                }
                else
                {

                    DesacLine();
                    /*if (ac.line2 && ac.line1)
                    {
                        ac.link = true;
                    }*/

                }
            }

            else if (TraceLine == true)
            {
                lineclone.SetActive(false);
                TraceLine = false;

            }
        }
    }

    void DesacLine()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            house house;
            house = hit.transform.gameObject.GetComponent<house>();


            if (hit.transform.tag == "House" && TraceLine == true)
            {
                lineclone.GetComponent<LineRenderer>().startColor = Color.yellow;
                lineclone.GetComponent<LineRenderer>().endColor = Color.yellow;
                lineDrawScript.enabled = false;
                TraceLine = false;

            }


        }
        else if (TraceLine == true)
        {
            lineclone.SetActive(false);
            TraceLine = false;
            print("desec");
        }
    }

    private void StockHouse()
    {
        if (Input.GetMouseButtonDown(0))
        { // if left button pressed...
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit) && hit.transform.CompareTag("House"))
            {
                Stock = hit.transform.gameObject.GetComponent<house>();
            }
        }
    }

    private void ActualHouse()
    {
        if (Input.GetMouseButtonUp(0))
        { // if left button pressed...
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit) && hit.transform.CompareTag("House") && TraceLine == true)
            {
                Actual = hit.transform.gameObject.GetComponent<house>();
            }
            else
            {
                Actual = null;
            }
        }
    }

    public void levelUpHouse()
    {
        if ( Gold >= GoldNeed)
        {
            print(Stock.levelHouse);
            Stock.levelHouse += 1;
            Gold = Gold - GoldNeed;
            GoldNeed = GoldNeed + 10;
            bUTTONSCRIPT.transform.position = bUTTONSCRIPT.pos;
            Multiplicateur = Multiplicateur + 0.5f;

        }
        else
        {

        }


    }

    public void DestroyAllLine()
    {
        for (int i = 0; i < ListLine.Count; i++)
        {
            DestroyLine = true;  
            Destroy(ListLine[i]);
     
        }
    }
}

