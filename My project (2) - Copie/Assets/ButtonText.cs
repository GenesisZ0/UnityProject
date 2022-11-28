using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ButtonText : MonoBehaviour
{
    GameManager gameManager;
    public Text Button;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();   
    }

    // Update is called once per frame
    void Update()
    {
        Button.text = "Upgrade this house for :" + gameManager.GoldNeed + " ?";
    }
}
