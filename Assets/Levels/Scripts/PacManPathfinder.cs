using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacManPathfinder : MonoBehaviour
{
    [SerializeField] private Vector2 posInGrid;
    [SerializeField] private TilemapGridGenerator TMgenerator;
    [SerializeField] private Transform targetTransform;

    private GhostMove movement;

    private bool test = true;
    private void Awake()
    {
        transform.position = TMgenerator.GetPositionInCell(posInGrid);
        movement = GetComponent<GhostMove>();


    }
    private void PrintPath(List<Vector2> path)
    {
        string pathString = "Path: ";
        for (int i = 0; i < path.Count; i++)
        {
            pathString += path[i].ToString();
            if (i < path.Count - 1)
                pathString += " -> ";
        }

        Debug.Log(pathString);
    }
    private List<Vector2> FindPath(Vector2 startPosition, Vector2 targetPosition)
    {
        List<Vector2> path = new List<Vector2>();

        // Create a queue for the breadth-first search
        Queue<Vector2> queue = new Queue<Vector2>();
        queue.Enqueue(startPosition);

        // Create a dictionary to store the parent of each visited cell
        Dictionary<Vector2, Vector2> parentMap = new Dictionary<Vector2, Vector2>();
        parentMap[startPosition] = startPosition;

        // Variable to track if the target is reachable
        bool targetFound = false;

        // Perform breadth-first search until the target position is found or no more cells to explore
        while (queue.Count > 0 && !targetFound)
        {
            Vector2 current = queue.Dequeue();

            if (current == targetPosition)
            {
                targetFound = true;
                break;
            }

            // Get the neighboring cells
            Vector2[] neighbors = TMgenerator.GetNeighboringCells(current);

            // Iterate through the neighbors
            foreach (Vector2 neighbor in neighbors)
            {
                // Check if the neighbor is valid and not visited
                if (TMgenerator.IsCellValid(neighbor) && !parentMap.ContainsKey(neighbor))
                {
                    // Enqueue the neighbor and update its parent
                    queue.Enqueue(neighbor);
                    parentMap[neighbor] = current;
                }
            }
        }

        // Check if the target position is reachable
        if (targetFound)
        {
            // Reconstruct the path from the target position to the start position
            Vector2 currentPos = targetPosition;
            while (currentPos != startPosition)
            {
                path.Insert(0, currentPos);
                currentPos = parentMap[currentPos];
            }
            path.Insert(0, startPosition);
        }
        else
        {
            Debug.Log("Target position is not reachable.");
        }

        return path;
    }
    private void Update()
    {
        if (test)
        {
            // Call the pathfinding method
            List<Vector2> path = FindPath(posInGrid, TMgenerator.WorldToGrid(targetTransform.position));

            // Do something with the path, e.g., pass it to GhostMove for movement
            PrintPath(path);
            test = false;
        }
    }
}
