using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PartsPlease;
using UnityEngine.UI;

public class BookTab : MonoBehaviour
{
    public Page desiredPage;
    public SchematicsBookController parent;
    public Button button;

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    void Start()
    {
        button.onClick.AddListener(delegate { parent.onChildClick(desiredPage); });
    }
}
