using UnityEngine;

public class Mine : Building
{
    //  This class adds X amount of resource to the player
    //  every t seconds

    private float resourceGenPeriod = 3.0f;

    internal override void PlaceOnTile(Tile _tile, Playerbase _owner)
    {
        base.PlaceOnTile(_tile, _owner);
        _buildingName = BuildingType.MINE;
        _parentTile = _tile;
        OnPlacedOnTile();
    }

    internal override void OnPlacedOnTile()
    {
        GenerateResource();
    }

    internal override void Demolish()
    {
        base.Demolish();
    }

    private void GenerateResource()
    {
        //  Sends message to player to add one resource
        TaskTree genResourcesTaskTree = new TaskTree(new WaitTask(resourceGenPeriod));
		Services.GameManager.players [Owner.owner - 1].numResources++;
        genResourcesTaskTree.Then(new ActionTask(GenerateResource));
        //  To do additional things just add more thens
        //  Add child to make other things happen as a result of a task
        _tm.AddTask(genResourcesTaskTree);
    }

    private void Update()
    {
        _tm.Update();
    }
}
