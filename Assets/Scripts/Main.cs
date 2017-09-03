using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : Scene<TransitionData> {

    private Agent agent;
	private Playerbase[] playerbases;

	// Use this for initialization
	void Start () {
        Services.MapManager.GenerateMap();

        agent = Instantiate(Services.Prefabs.Agent, Services.Main.transform).GetComponent<Agent>();
        agent.Walk();
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
