﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnstoppableShotBody : ShotBody
{
    protected GameManager gameManager;
    protected void Awake()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    public override void ExitDestroy()
    {
        base.ExitDestroy();
    }
    public override void ShotDestroy(RangeController rangeController)
    {
        if (gameManager.BonusManager.IsAutoRange)
        {
            base.ShotDestroy(rangeController);
            return;
        }

    }
    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            FindObjectOfType<AudioManager>().Play("Explosion");
            gameManager.Player.Controller.Dead();
            ExitDestroy();
        }
    }
}
