using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Prefab DB")]
public class PrefabDB : ScriptableObject {
    [SerializeField]
    private GameObject[] scenes;
    public GameObject[] Scenes { get { return scenes; } }

    [SerializeField]
    private GameObject tile;
    public GameObject Tile { get { return tile; } }

    [SerializeField]
    private GameObject resource;
    public GameObject Resource { get { return resource; } }

    [SerializeField]
    private GameObject agent;
    public GameObject Agent { get { return agent; }}

	[SerializeField]
	private GameObject playerbase;
	public GameObject Playerbase { get { return playerbase; }}

    [SerializeField]
    private GameObject[] buildingsTypes;
    public GameObject[] BuildingTypes { get { return buildingsTypes; } }

}
