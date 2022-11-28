using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class house : MonoBehaviour
{
    LineDraw lineDraw;
    private GameObject Myhouse;
    [SerializeField] bool verif = false;
    public bool line1 = false;
    public bool line2 = false;
    private bool Test;
    public house StocHouse;
    public house ActualhIThOUSE;
    private BUTTONSCRIPT bUTTONSCRIPT;
    GameManager gameManager;
    [SerializeField] MeshFilter MeshFilter;
    [SerializeField] Mesh lv2;
    public bool link;
    public int levelHouse = 0;
    public bool DontSpawn;
    ParticleSystem Firework;




    // Start is called before the first frame update
    void Start()
    {
        lineDraw = GetComponent<LineDraw>();
        bUTTONSCRIPT= FindObjectOfType<BUTTONSCRIPT>();
        gameManager = FindObjectOfType<GameManager>();
        Firework = GetComponent<ParticleSystem>();
      
      
    }   

    // Update is called once per frame
    void Update()
    {
        if (levelHouse >= 1)
        {
            MeshFilter.mesh = lv2;
        }

        if (line1&& line2) 
        {
        link = true;
        }
      
        print(DontSpawn);
      
    }

    private void OnMouseDown()
    {
        house HitHouse;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform.tag == "House")
            {

                HitHouse = hit.transform.gameObject.GetComponent<house>();
                StocHouse = HitHouse;
                

            }

            
        }
    }

    private void OnMouseUp()
    {

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            house HitHouse;
            HitHouse = hit.transform.gameObject.GetComponent<house>();
            ActualhIThOUSE = HitHouse;
            if (hit.transform.tag == "House" )
            {
                
                if (StocHouse == HitHouse )
                {
                 
                }
                else if (!HitHouse.line1 && !HitHouse.line2 || !HitHouse.line1 && HitHouse.line2 || HitHouse.line1 && !HitHouse.line2)  
                {
                    print("fait la fonction");
                    lockLineFinish(HitHouse);
                    lockLineStart();
                    HitHouse.GetComponent<ParticleSystem>().Play();

                }
                else
                {
                    print("fait rine");
                }
               
            }

            if (HitHouse == StocHouse)
            {
                bUTTONSCRIPT.transform.position = new Vector3(gameManager.Stock.transform.position.x , gameManager.Stock.transform.position.y + 0, gameManager.Stock.transform.position.z + 7);
            }
        }
        
    }

    public void lockLineStart()
    {

        if (gameManager.Stock.line1 == false && gameManager.Stock.line2 == false )
        {
            gameManager.Stock.line1 = true;

            

        }
        else if (gameManager.Stock.line1 == true && gameManager.Stock.line2 == false)
        {
            gameManager.Stock.line2 = true;
          
        }
        else if (gameManager.Stock.line2 == true && gameManager.Stock.line1 == false)
        {
            gameManager.Stock.line1 = true;
           
        }
        else
        {
           
        }
        
    }
    public void lockLineFinish(house h)
    {
        if (h.line1 == false && h.line2 == false)
        {
            h.line1 = true;
            print("etst1");


        }
        else if (h.line1 == true && h.line2 == false)
        {
            print("etst3");
            h.line2 = true;

        }
        else if (h.line2 == true && h.line1 == false)
        {
            h.line1 = true;
            print("etst4");


        }
        
    }

    public void OnTriggerEnter(Collider other)
    {
        
        //other.transform.position = new Vector3( other.transform.position.x + Random.Range (5, 10), -70, other.transform.position.z + Random.Range(5, 10));
    }

}
