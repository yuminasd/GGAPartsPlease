using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PartsPlease;

public class PartPromptButton : MonoBehaviour
{

    public WeaponPart part;
    public PartPromptController parent;
   public Button activator;
   void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    void Start()
    {
        activator.onClick.AddListener(delegate { parent.showPrompt(part); });
    }
}
