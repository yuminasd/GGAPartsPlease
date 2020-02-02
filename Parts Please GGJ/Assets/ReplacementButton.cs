using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PartsPlease;
using UnityEngine.UI;

public class ReplacementButton : MonoBehaviour
{
    public PartType replacementType;
    public ReplacementChooserController parent;
    public Button activationButton;

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    void Start()
    {
        activationButton.onClick.AddListener(delegate { parent.onReplacementClick(replacementType); });
    }
}
