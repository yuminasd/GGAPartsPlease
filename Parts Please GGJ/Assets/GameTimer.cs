using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTimer : MonoBehaviour
{
    [SerializeField]
    private int CurrentTime;
    private int StartTime = 0;
    private int EndTime = 600;
    [SerializeField]
    private float Timer;
    private bool KeepTime;

    public GameController gameController;
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
            if (gameController.getGameState().currentCustomer.LastCustomer && gameController.getGameState().currentCustomer.HasExited)
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
        this.gameController.getGameState().currentCustomer.setLastCustomer(true);
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
