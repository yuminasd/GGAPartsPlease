using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponLocationFollow : MonoBehaviour
{
    Transform WeaponCarryPosition;
    bool RepairLock;
    // Start is called before the first frame update
    void Start()
    {
        this.RepairLock = true;
    }

    // Update is called once per frame
    void Update()
    {
        this.SetCarryPosition();
    }

    private void SetCarryPosition()
    {
        this.transform.position = WeaponCarryPosition.position;
    }
    public void SetRepairLock(bool state)
    {
        this.RepairLock = state;
    }
}
