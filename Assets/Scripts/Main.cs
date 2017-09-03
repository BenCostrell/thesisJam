using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Main : Scene<TransitionData> {

    private Agent agent;

	private Text resourceText;

	// Use this for initialization
	void Start () {
		resourceText = GameObject.Find ("ResourceText").GetComponent<Text> ();
        Services.MapManager.GenerateMap();

		IntVector2 center = Services.MapManager.CenterIndexOfGrid ();

		agent = Instantiate(Services.Prefabs.Agent, Services.MapManager.map[center.x, center.y].gameObject.transform.position, Quaternion.identity, Services.Main.transform).GetComponent<Agent>();
        agent.CalculatePath();
	}
	
	// Update is called once per frame
	void Update () {

		resourceText.text = Services.GameManager.players [0].numResources.ToString () + "r";
		
	}

    void InitializeServices()
    {
        Services.Main = this;
        Services.MapManager = GetComponentInChildren<MapManager>();
        Services.BuildingManager = GetComponentInChildren<BuildingManager>();
		Services.Construt = GetComponentInChildren<Construt> ();
    }

		
    internal override void OnEnter(TransitionData data)
    {
        InitializeServices();
		Services.GameManager.currentCamera = GetComponentInChildren<Camera> ();
	}
}