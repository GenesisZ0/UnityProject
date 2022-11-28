using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    public List<GameObject> ListHouse;
    [SerializeField] GameObject housePrefab;
    [SerializeField] Vector3 center;
    [SerializeField] float Cooldown;
    float LastSpawn;
    [SerializeField] Vector3 size;
    public GameObject HouseClone = null;
    public Vector3 TransformHouse;
    public int NumberHouse = 0;
    public Canvas CanvasUIElement;
    GameManager gameManager;
    


    /// private bool Spawn = false; 
    // Start is called before the first frame update
    void Start()
    {
    
        gameManager = FindObjectOfType<GameManager>();
     
    }

    // Update is called once per frame
    void Update()
    {
       
        if (gameManager.DestroyLine == true)
        {
            for (int i = 0; i < ListHouse.Count; i++)
            {
                ListHouse[i].GetComponent<house>().line1 = false;
                ListHouse[i].GetComponent<house>().line2 = false;
                ListHouse[i].GetComponent<house>().link = false;
            }
        }

        SpawnHouse();

    }

    public void SpawnHouse()
    {
        Vector3 pos = center + new Vector3(Random.Range(-size.x / 2, size.x/2), Random.Range(-size.y / 2, size.y / 2), Random.Range(-size.z / 2, size.z/ 2));

        if (Time.time - LastSpawn < Cooldown)
        {
            return;
        }
        LastSpawn = Time.time;
        if (NumberHouse < 1)
        {
            
            HouseClone = Instantiate(housePrefab, pos, Quaternion.identity);
            ListHouse.Add(HouseClone);
            HouseClone.transform.DOScale(0.8f,0.8f);
            TransformHouse = HouseClone.transform.position;
         
            NumberHouse += 1;
        }
        
    }

  

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1,0,0,0.5f);
        Gizmos.DrawCube(center,size);
    }

   

   
}
 