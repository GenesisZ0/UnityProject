using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Route : MonoBehaviour
{
    LineDraw lineDraw;
    GameManager gameManager;
    [SerializeField] bool HitHouse = false;
    [SerializeField] GameObject gameManager2;
    public int Gold = 0;
    private float LastGold;
    [SerializeField] float Cooldown;
    EdgeCollider2D edgeCollider;
    LineRenderer lineRenderer;
    house house;
    Canvas canvas;
    ScoreScript NumberGold;
    [SerializeField] GoldScript goldScript;
    ParticleSystem ParticleSystem;
    private Vector3 pose;

    // Start is called before the first frame update
    void Start()
    {
        lineDraw = GetComponent<LineDraw>();
        gameManager = FindObjectOfType<GameManager>();
        edgeCollider = this.GetComponent<EdgeCollider2D>();
        house = FindObjectOfType<house>();  
        NumberGold = FindObjectOfType<ScoreScript>();
        ParticleSystem = GetComponent<ParticleSystem>();
        canvas= FindObjectOfType<Canvas>();
      

    }

    // Update is called once per frame
    void Update()
    {
        GetGold(lineDraw.lenght);
        pose = Input.mousePosition;
        pose.z = 20;
            
        ParticleSystem.transform.position = Camera.main.ScreenToWorldPoint(pose);
      
        if (Input.GetMouseButtonUp(0))
        {
            
            ParticleSystem.Stop();
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                HitHouse = true;

            }
        }   
    }
    public void GetGold(float Length)
    {
        if (gameManager.Actual == gameManager.Stock) 
        {
            print("pa de money");
           
        }
        else
        {
            if (Length > 0 && Length < 30 && HitHouse == true)
            {

                if (Time.time - LastGold < Cooldown)
                {
                    return;
                }
                LastGold = Time.time;
                GoldScript gold = Instantiate(goldScript, new Vector3(NumberGold.transform.position.x +13, NumberGold.transform.position.y -15, NumberGold.transform.position.z),NumberGold.transform.rotation) ;
                gold.Gold.text = "+ 2 Gold" ;
                gold.transform.SetParent(canvas.transform);
                Destroy(gold.gameObject,3f);
                gameManager.Gold += 2;
            }
            else if (Length > 30 && HitHouse == true)
            {
                if (Time.time - LastGold < Cooldown)
                {
                    return;
                }
                LastGold = Time.time;
                Mathf.Round(gameManager.Gold += 1 * gameManager.Multiplicateur);
            }

        }


    }

 

}
