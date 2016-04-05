using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class ScoresManager : MonoBehaviour
{
    public int moneyStart = 400;
    public int money = 400;
    public int lives = 20;
    public int livesMax = 20;
    public int numLevel = 0;

    void Start()
    {

    }
    	
    void Update()
    {

    }
    	
    public bool CanBuyForCost(int cost)
    {
        return cost <= money;
    }
    	
    public int GetMoney()
    {
        return money;
    }
    	
    public void UseMoney(int cost)
    {
        if (cost <= money)
            money -= cost;
    }

    
    public void RecivedMoney(int gold)
    {
        money += gold;
    }
       
    public void restart()
    {
        lives = livesMax;
        money = moneyStart;
    }
}