using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PartsPlease;

public class GameTimer : MonoBehaviour
{
    [SerializeField]
    private int CurrentTime;
    private int StartTime = 0;
    private int EndTime = 1;
    [SerializeField]
    private float Timer;
    private bool KeepTime;
    private bool ShopHasClosed = false;

    public GameState gameState;
    public GameObject OpenShopButton;
    public Animator Anim_ShipDoor;
    public MoneyController mc;


    public SpriteRenderer sr;
    public Sprite[] sprites = new Sprite[6];
    private int imageIndex;
    private float switchTime;
    private float switchTimer;





    // Start is called before the first frame update
    void Start()
    {


        this.KeepTime = false;
        this.CurrentTime = 0;
        this.Timer = 0;

        this.imageIndex = 0;
        this.switchTimer = 0;
        this.switchTime = EndTime / 6;

        sr = GetComponentInChildren<SpriteRenderer>();

        sr.sprite = sprites[0];


    }

    // Update is called once per frame
    void Update()
    {
        switchBackGroundImages();

        if (this.KeepTime)
        {
            this.Timer += Time.deltaTime;
            this.switchTimer += Time.deltaTime;
            this.CurrentTime = Mathf.FloorToInt(this.Timer);

        }
        if (this.Timer >= this.EndTime)
        {
            this.StopTimer();
        }
        if (this.CurrentTime >= this.EndTime && !this.KeepTime)
        {
            if (gameState.currentCustomer.LastCustomer && gameState.currentCustomer.customerState == CustomerState.Exited)
            {
                if (!this.ShopHasClosed)
                {
                    this.CloseShop();
                }
            }
        }
    }

    public void ResetTimer()
    {
        this.CurrentTime = 0;
        this.Timer = 0;
        this.switchTimer = 0;
        
    }

    public void StartTimer()
    {
        this.KeepTime = true;
        this.ShopHasClosed = false;
    }

    public void StopTimer()
    {
        this.KeepTime = false;
        gameState.currentCustomer.setLastCustomer(true);
 
    }

    public void HideOpenShopButton()
    {
        OpenShopButton.SetActive(false);
    }

    public void OpenShop()
    {
        Anim_ShipDoor.SetTrigger("Trig_OpenShop");
  
    }

    public void CloseShop()
    {
        this.ShopHasClosed = true;
        Anim_ShipDoor.SetTrigger("Trig_CloseShop");
        mc.openShop = false;
    }
    public void closeImages()
    {
        if (imageIndex > 5)
        {
            imageIndex = 0;
        }

        sr.sprite = sprites[imageIndex];

    }
    private void switchBackGroundImages()
    {

        if (switchTimer >= switchTime)
        {
            Debug.Log("Time switch");
            switchTimer = 0;
            imageIndex++;
            closeImages();


        }

    }


}
