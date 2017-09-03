using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : Scene<TransitionData> {

    private Agent agent;

	// Use this for initialization
	void Start () {
        Services.MapManager.GenerateMap();

		IntVector2 center = Services.MapManager.CenterIndexOfGrid ();

		agent = Instantiate(Services.Prefabs.Agent, Services.MapManager.map[center.x,center.y].gameObject.transform).GetComponent<Agent>();
        agent.CalculatePath();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void InitializeServices()
    {
        Services.Main = this;
        Services.MapManager = GetComponentInChildren<MapManager>();
        Services.BuildingManager = GetComponentInChildren<BuildingManager>();
    }

		
    internal override void OnEnter(TransitionData data)
    {
        InitializeServices();
		Services.GameManager.currentCamera = GetComponentInChildren<Camera> ();
	}
}