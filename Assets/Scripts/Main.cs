using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : Scene<TransitionData> {

    private Agent agent;
	private Playerbase[] playerbases;

	// Use this for initialization
	void Start () {
        Services.MapManager.GenerateMap();

		IntVector2 center = Services.MapManager.CenterIndexOfGrid ();

		agent = Instantiate(Services.Prefabs.Agent, Services.MapManager.map[center.x,center.y].gameObject.transform).GetComponent<Agent>();
        agent.Walk();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void InitializeServices()
    {
        Services.Main = this;
        Services.MapManager = GetComponentInChildren<MapManager>();
    }

		
    internal override void OnEnter(TransitionData data)
    {
        InitializeServices();
		Services.GameManager.currentCamera = GetComponentInChildren<Camera> ();
	}
}