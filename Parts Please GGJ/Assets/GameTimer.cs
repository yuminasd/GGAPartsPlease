using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PartsPlease;

public class GameTimer : MonoBehaviour
{
    [SerializeField]
    private int CurrentTime;
    private int StartTime = 0;
    private int EndTime = 180;
    [SerializeField]
    private float Timer;
    private bool KeepTime;

    public GameState gameState;
    public GameObject OpenShopButton;
    public Animator Anim_ShipDoor;

    // Start is called before the first frame update
    void Start()
    {
        this.KeepTime = false;
        this.CurrentTime = 0;
        this.Timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.KeepTime)
        {
            this.Timer += Time.deltaTime;
            this.CurrentTime = Mathf.FloorToInt(this.Timer);
        }
        if(this.Timer >= this.EndTime)
        {
            this.StopTimer();
        }
        if(this.CurrentTime >= this.EndTime && !this.KeepTime)
        {
            if (gameState.currentCustomer.LastCustomer && gameState.currentCustomer.customerState == CustomerState.Exited)
            {
                this.CloseShop();
            }
        }
    }

    public void ResetTimer()
    {
        this.CurrentTime = 0;
        this.Timer = 0;
    }

    public void StartTimer()
    {
        this.KeepTime = true;
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
        Anim_ShipDoor.SetTrigger("Trig_CloseShop");
    }

}
