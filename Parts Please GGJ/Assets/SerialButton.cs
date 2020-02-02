using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PartsPlease;

public class SerialButton : MonoBehaviour
{
    public string serialNumber;
    public ReplacementChooserController parent;
    public Button activator;

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    void Start()
    {
        activator.onClick.AddListener(delegate { parent.onSerialClick(serialNumber);});
    }
}
