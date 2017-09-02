using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : Scene<TransitionData> {

	// Use this for initialization
	void Start () {
        Services.MapManager.GenerateMap();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    internal override void OnEnter(TransitionData data)
    {
        InitializeServices();
    }

    void InitializeServices()
    {
        Services.Main = this;
        Services.MapManager = GetComponentInChildren<MapManager>();
    }
}
