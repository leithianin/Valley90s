﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CabaneManager : MonoBehaviour
{
    public static CabaneManager instance;

    [SerializeField]
    private int argent = 5;

    [SerializeField]
    public GameObject floatingText;

    [SerializeField]
    private Balise cabaneBalise;

    public Balise GetCabaneBalise { get { return cabaneBalise; } }

    float timeLeftBeforeMonney;

    public TextMeshProUGUI money;

    private void Awake()
    {
        instance = this;
        money.text = argent.ToString();
    }

    private void Update()
    {
        timeLeftBeforeMonney += Time.deltaTime;
        if(timeLeftBeforeMonney > 30)
        {
            timeLeftBeforeMonney = 0;
            AddArgent(VisitorSpawner.instance.GetVisitorInValley * 1);
        }
    }

    public void AddArgent(int nbToAdd)
    {
        argent += nbToAdd;
        money.text = argent.ToString();
        //floatingText.SetActive(true);
    }

    public bool CanPutBalise()
    {
        return argent >= 5;
    }

    public void UseBalise()
    {
        argent -= 5;
    }
}
