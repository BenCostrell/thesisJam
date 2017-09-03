using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player {

    public int playerNum;
    [SerializeField] private int numResources_;
    public int numResources
    {
        get
        {
            return numResources_;
        }
        set
        {
            numResources_ = value;
            //resourceUI.text = value.ToString();
        }
    }

    public Player(int playerNum_)
    {
        playerNum = playerNum_;
    }

}
