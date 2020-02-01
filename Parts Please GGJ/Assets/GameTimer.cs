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

    public GameObject OpenShopButton;

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
    }

    public void HideOpenShopButton()
    {
        OpenShopButton.SetActive(false);
    }
}
