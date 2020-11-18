﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JumpAndReachGameMode : MonoBehaviour, 
    InputHandler.GameRule,
    TriggerVolume.GameRule,
    MyPlayer.GameRule
{
    public GameObject startPosition;

    protected virtual void InjectOnAwake()
    {
        InputHandler.gameRule = this;
        TriggerVolume.gameRule = this;
        MyPlayer.gameRule = this;
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

    IEnumerator GameOverAndRespawnCoroutine(MyPlayer myPlayer)
    {
        playerControlEnable = false;
        Debug.Log("GameOver");
        yield return new WaitForSeconds(3);
        myPlayer.TeleportAt( startPosition.transform.position );
        playerControlEnable = true;
    }

    IEnumerator GameWinCoroutine()
    {
        playerControlEnable = false;
        Debug.Log("GameWin");
        yield return new WaitForSeconds(3);
        MyGameInstance.instance.hasCleared = true;
        SceneManager.LoadScene(0);
    }

    void TriggerVolume.GameRule.OnTriggerEnter2D(TriggerVolume triggerVolume, TriggerVolume.Type type, Collider2D collision)
    {
        switch(type)
        {
            case TriggerVolume.Type.Death:
                OnTriggerEnter2DDeath(triggerVolume, collision);
                break;
            case TriggerVolume.Type.Win:
                OnTriggerEnter2DWin(triggerVolume, collision);
                break;
            default:
                break;
        }
    }
    protected void OnTriggerEnter2DDeath(TriggerVolume triggerVolume, Collider2D collision)
    {
        MyPlayer myPlayer = collision.GetComponent<MyPlayer>();
        if(myPlayer != null)
            myPlayer.Die();
    }

    protected void OnTriggerEnter2DWin(TriggerVolume triggerVolume, Collider2D collision)
    {
        MyPlayer myPlayer = collision.GetComponent<MyPlayer>();
        if (myPlayer != null)
        { 
            myPlayer.Ceremony();
            StartCoroutine(GameWinCoroutine());
        }

    }

    public bool playerControlEnable = true;
    bool InputHandler.GameRule.HasPermission(InputHandler inputHandler, InputHandler.Type type)
    {
        switch (type)
        {
            case InputHandler.Type.Player:
                return playerControlEnable;
            default:
                return false;
        }
    }

    void MyPlayer.GameRule.OnDeath(MyPlayer myPlayer)
    {
        StartCoroutine(GameOverAndRespawnCoroutine(myPlayer));
    }
}
