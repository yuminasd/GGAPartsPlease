using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using PartsPlease;
using TMPro;



public class MoneyController : MonoBehaviour
{
    // Start is called before the first frame update
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);

    }


    public int money;
    public TextMeshProUGUI displayMoney;
    public GameObject shop;
    public bool canShop = true;
    public bool finishedShopping = false;
    public bool openShop = false;


    void Start()
    {
        shop.gameObject.SetActive(false);

      
        money = 1000;
     
   
    }
    private void Update()
    {
        displayMoney.text = "$ " + money.ToString();
    }

    public void purchaseItem(int moneyToSpend)
    {
        if (money - moneyToSpend >= 0)
        {
            money -= moneyToSpend;
        }
    }

    public void OnClicked(Button button)
    {
        GameObject.Find(button.name).GetComponent<Button>().interactable = false;
        
    }

    public void startNewDay ()
    {
        Debug.Log("Disabling shop");
        shop.SetActive(false);
  


    }

    
    public void resetOpenShop() { 
    
        this.openShop = false;    
    }
}
