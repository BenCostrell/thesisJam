using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public static class AStarSearch
{
    public static float Heuristic(NavQuad a, NavQuad b)
    {
        return NavQuad.Distance(a, b);
    }

    public static List<NavQuad> ShortestPath(NavQuad start, NavQuad goal, bool raw)
    {
        List<NavQuad> path = new List<NavQuad>();
        Dictionary<NavQuad, NavQuad> cameFrom = new Dictionary<NavQuad, NavQuad>();
        Dictionary<NavQuad, float> costSoFar = new Dictionary<NavQuad, float>();
        NavQuad estimatedClosestQuad = start;

        PriorityQueue<NavQuad> frontier = new PriorityQueue<NavQuad>();
        frontier.Enqueue(start, 0);
        cameFrom[start] = start;
        costSoFar[start] = 0;

        while (frontier.Count > 0)
        {
            NavQuad current = frontier.Dequeue();
            if (Heuristic(current, goal) < Heuristic(estimatedClosestQuad, goal))
            {
                estimatedClosestQuad = current;
            }
            if (current == goal) break;
            foreach (NavQuad next in current.neighbors)
            {
                if (!next.IsImpassable())
                {
                    float newCost;
                    if (raw)
                    {
                        newCost = costSoFar[current] + 1;
                    }
                    else
                    {
                        newCost = costSoFar[current] + next.movementCost;
                    }

                    if (!costSoFar.ContainsKey(next) || newCost < costSoFar[next])
                    {
                        costSoFar[next] = newCost;
                        float priority = newCost + Heuristic(next, goal);
                        frontier.Enqueue(next, priority);
                        cameFrom[next] = current;
                    }
                }
            }

        }
        NavQuad pathNode = estimatedClosestQuad;
        while(pathNode != start)
        {
            path.Add(pathNode);
            pathNode = cameFrom[pathNode];
        }
        path.Reverse();

        return path;
    }

    public static List<NavQuad> FindAllAvailableGoals(NavQuad start, float movementAvailable, bool raw)
    {
        List<NavQuad> availableGoals = new List<NavQuad>();
        if (movementAvailable == 0) return availableGoals;
        Dictionary<NavQuad, NavQuad> cameFrom = new Dictionary<NavQuad, NavQuad>();
        Dictionary<NavQuad, float> costSoFar = new Dictionary<NavQuad, float>();

        Queue<NavQuad> frontier = new Queue<NavQuad>();
        frontier.Enqueue(start);
        cameFrom[start] = start;
        costSoFar[start] = 0;

        while (frontier.Count > 0)
        {
            NavQuad current = frontier.Dequeue();
            if (costSoFar[current] <= movementAvailable)
            {
                if (current != start) availableGoals.Add(current);
                foreach (NavQuad next in current.neighbors)
                {
                    if (!next.IsImpassable() || raw)
                    {
                        float newCost;
                        if (raw)
                        {
                            newCost = costSoFar[current] + 1;
                        }
                        else
                        {
                            newCost = costSoFar[current] + next.movementCost;
                        }
                        if (!costSoFar.ContainsKey(next) || newCost < costSoFar[next])
                        {
                            costSoFar[next] = newCost;
                            frontier.Enqueue(next);
                            cameFrom[next] = current;
                        }
                    }
                }
            }
        }
        return availableGoals;
    }
}

public class PriorityQueue<T>
{
    public List<PrioritizedItem<T>> elements = new List<PrioritizedItem<T>>();

    public int Count { get { return elements.Count; } }

    public void Enqueue(T item, float priority)
    {
        elements.Add(new PrioritizedItem<T>(item, priority));
    }

    public T Dequeue()
    {
        int bestIndex = 0;
        for (int i = 0; i < elements.Count; i++)
        {
            if (elements[i].priority < elements[bestIndex].priority) bestIndex = i;
        }

        T bestItem = elements[bestIndex].item;
        elements.RemoveAt(bestIndex);
        return bestItem;
    }
}

public class PrioritizedItem<T>
{
    public T item;
    public float priority;
    public PrioritizedItem(T item_, float priority_)
    {
        item = item_;
        priority = priority_;
    }
}
