using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PartsPlease
{

    public class ReplacementChooserController : MonoBehaviour
    {
        public GameObject[] activationButtons;
        public GameObject replacementChooser;
        public GameObject chooseArrowHint;
        public GameObject serialBook;
        public GameObject bulbSerialPage, gearSerialPage, scopeSerialPage;

        public WeaponController weaponController;
        //public GameObject 
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void showReplacementChooser()
        {
            replacementChooser.SetActive(true);
            chooseArrowHint.SetActive(true);
            foreach (GameObject obj in activationButtons)
            {
                obj.SetActive(true);
            }
        }

        public void resetReplacementChooser()
        {
            serialBook.SetActive(false);
            chooseArrowHint.SetActive(false);
            foreach(GameObject obj in activationButtons)
            {
                obj.SetActive(false);
            }
            replacementChooser.SetActive(false);
        }

        public void onReplacementClick(PartType type)
        {
            chooseArrowHint.SetActive(false);
            serialBook.SetActive(true);
            bulbSerialPage.SetActive(false);
            gearSerialPage.SetActive(false);
            scopeSerialPage.SetActive(false);
            switch (type)
            {
                case PartType.Bulb:
                    bulbSerialPage.SetActive(true);
                    break;
                case PartType.Gear:
                    gearSerialPage.SetActive(true);
                    break;
                case PartType.Scope:
                    scopeSerialPage.SetActive(true);
                    break;
            }
        }

        public void onSerialClick(string serial)
        {
            Debug.Log("Replace with: " + serial);
            WeaponPart part = weaponController.activePart;
            Debug.Log("CURRENT: " + part.serialNumber);
            part.serialNumber = serial;
            part.isBroken = false;;
            Debug.Log("After Fix: " + part.serialNumber);
            weaponController.currentParts[part.index] = part;
            weaponController.activePart = null;
            this.resetReplacementChooser();
        }
    }

}
