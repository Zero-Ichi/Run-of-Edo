﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreController : Base
{

    protected TextMeshProUGUI scoreTxt;

    // Start is called before the first frame update
    void Start()
    {
        scoreTxt = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float formatedScore = GameManager.Score * 1000;
        if (formatedScore > 99999999999)
        {
            formatedScore = 99999999999;
        }
        scoreTxt.text = Mathf.Round(formatedScore).ToString();
    }
}
