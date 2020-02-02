using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PartsPlease;

namespace PartsPlease
{
    public enum Page
    {
        Cover,
        Models,
        Lights,
        Scopes,
        Gears
    }

    public class SchematicsBookController : MonoBehaviour
    {

        public GameObject schematicsBookOpen;
        public GameObject schematicsBook;
        public GameObject modelsPage, lightsPage, gearsPage, scopesPage;
        Page page;

        // Start is called before the first frame update
        void Start()
        {
            page = Page.Models;
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void onChildClick(Page desiredPage)
        {
            Debug.Log("desiring page" + desiredPage);
            schematicsBookOpen.SetActive(true);
            modelsPage.SetActive(false);
            lightsPage.SetActive(false);
            gearsPage.SetActive(false);
            scopesPage.SetActive(false);
            switch (desiredPage)
            {
                
                case Page.Cover:
                    schematicsBookOpen.SetActive(false);
                    break;
                case Page.Models:
                    modelsPage.SetActive(true);
                    break;
                case Page.Lights:
                    lightsPage.SetActive(true);
                    break;
                case Page.Gears:
                    gearsPage.SetActive(true);
                    break;
                case Page.Scopes:
                    scopesPage.SetActive(true);
                    break;
            }
        }
    }
}
