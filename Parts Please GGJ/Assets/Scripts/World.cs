using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PartsPlease
{
    public enum Faction
    {
        Neutral,
        Opfor,
        Blufor
    }

    public class World
    {
        short day; //starts at day 1
        short time; //measured in seconds
        short threatLevel; //starts at 1
    }
}
