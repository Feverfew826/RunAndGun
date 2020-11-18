using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GunSpecification
{
    public enum ShootType
    {
        SemiAuto,
        Burst,
        FullAuto
    }

    public ShootType shootType;
    public int loadedNum;
    public int maxLoadSize;
    public int bullets;
    public int maxBulletSize;
}
