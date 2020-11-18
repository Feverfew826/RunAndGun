using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunAndGunGameMode : JumpAndReachGameMode,
    TriggerVolume.GameRule
{
    protected override void InjectOnAwake()
    {
        base.InjectOnAwake();
        TriggerVolume.gameRule = this;
    }
    void TriggerVolume.GameRule.OnTriggerEnter2D(TriggerVolume triggerVolume, TriggerVolume.Type type, Collider2D collision)
    {
        MyPlayer myPlayer = collision.GetComponent<MyPlayer>();
        if (myPlayer != null)
        {
            switch (type)
            {
                case TriggerVolume.Type.Death:
                    OnTriggerEnter2DDeath(triggerVolume, collision);
                    break;
                case TriggerVolume.Type.Win:
                    OnTriggerEnter2DWin(triggerVolume, collision);
                    break;
                case TriggerVolume.Type.Weapon:
                    OnTriggerEnter2DWeapon(triggerVolume, collision);
                    break;
                default:
                    break;
            }
        }
    }

    protected void OnTriggerEnter2DWeapon(TriggerVolume triggerVolume, Collider2D collision)
    {
        MyPlayer myPlayer = collision.GetComponent<MyPlayer>();
        if (myPlayer != null)
        {
            Gun gun = triggerVolume.GetComponent<Gun>();
            myPlayer.Equip(gun);
        }
    }

    void Awake()
    {
        InjectOnAwake();
    }

    // Start is called before the first frame update
    void Start()
    {

    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
