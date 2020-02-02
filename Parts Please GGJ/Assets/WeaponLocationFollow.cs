using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponLocationFollow : MonoBehaviour
{
    public Transform CustomerPosition;
    Vector3 WeaponCarryOffset;

    float wX = 0.0f;
    float wY = 0.0f;
    float wZ = 0.0f;

    bool RepairLock;
    // Start is called before the first frame update
    void Start()
    {
        WeaponCarryOffset = new Vector3(wX, wY, wZ);
        this.transform.position = CustomerPosition.position + WeaponCarryOffset;
        this.RepairLock = true;
    }

    // Update is called once per frame
    void Update()
    {
        this.SetCarryPosition();
    }

    private void SetCarryPosition()
    {
        this.transform.position = CustomerPosition.position + WeaponCarryOffset;
    }
    public void SetRepairLock(bool state)
    {
        this.RepairLock = state;
    }
}
