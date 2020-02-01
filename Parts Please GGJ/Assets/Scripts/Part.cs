using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PartsPlease
{
    public enum PartState
    {
        Working,
        IndiscernibleIssue,
        InternalIssue,
        PhysicalDamage,
        MajorPhysicalDamage,
        LooseConnection
    }

    public class Part
    {
        short serialNumber;
        PartState state;
    }

}