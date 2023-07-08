using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapGridGenerator : MonoBehaviour
{
    [SerializeField] private Tilemap tilemap;
    public int[,] gridMatrix;

    private void Awake()
    {
        GenerateGridMatrix();

    }
    public Vector2[] GetNeighboringCells(Vector2 cell) 
    {
        
        Vector2[] neighbors = new Vector2[] { new Vector2(1, 0), new Vector2(-1, 0), new Vector2(0, 1), new Vector2(0, -1) };
        for (int i = 0; i<4; i++)
        {
            neighbors[i] = cell + neighbors[i];
        }
        return neighbors;
    }

    public bool IsCellValid(Vector2 cell)
    {
        int x = (int)cell.x;
        int y = (int)cell.y;

        // Check if the cell is within the grid bounds
        if (x >= 0 && x < gridMatrix.GetLength(0) && y >= 0 && y < gridMatrix.GetLength(1))
        {
            // Check if the cell is a free space (0)
            return gridMatrix[x, y] == 0;
        }

        return false;
    }
    public void GenerateGridMatrix()
    {
        BoundsInt bounds = tilemap.cellBounds;
        TileBase[] allTiles = tilemap.GetTilesBlock(bounds);

        gridMatrix = new int[bounds.size.x, bounds.size.y];

        for (int y = 0; y < bounds.size.y; y++)
        {
            for (int x = 0; x < bounds.size.x; x++)
            {
                TileBase tile = allTiles[x + (bounds.size.y - y - 1) * bounds.size.x];
                if (tile != null)
                {
                    // Set the corresponding value in the gridMatrix
                    gridMatrix[x, y] = 1; // You can assign any value based on your tile properties
                }
                else
                {
                    gridMatrix[x, y] = 0; // You can assign any value for empty cells
                }
            }
        }

        // Print out the gridMatrix
        //PrintGridMatrix();
    }
    public Vector3 GetPositionInCell(Vector2 xy)
        //gives coo of cell at matric position
    {
        Vector3Int cellPosition = tilemap.origin;

        float startX = cellPosition.x + (xy.x * tilemap.cellSize.x) + 0.5f;
        float startY = cellPosition.y + ((tilemap.size.y - xy.y - 1) * tilemap.cellSize.y) + 0.5f;

        return new Vector3(startX, startY, 0f);
    }

    public Vector2 WorldToGrid(Vector2 xy)
        //gives matrix position of cell at given coo
    {
        Vector3Int cellPosition = tilemap.origin;

        float X = xy.x - cellPosition.x - 0.5f;
        float Y = -xy.y + cellPosition.y + 0.5f + tilemap.size.y - 1;

        return new Vector2(X, Y);
    }

    public Vector3 GetCellAtPosition(Vector3 worldPosition)
        //gives coo of cell that position is inside
    {
        Vector3Int cellPosition = tilemap.WorldToCell(worldPosition);

       return cellPosition + new Vector3(0.5f, 0.5f, 0);

    }


    private void PrintGridMatrix()
    {
        int rows = gridMatrix.GetLength(0);
        int columns = gridMatrix.GetLength(1);

        Debug.Log("Grid Matrix:");

        for (int y = 0; y < columns; y++)
        {
            string rowString = "";
            for (int x = 0; x < rows; x++)
            {
                rowString += gridMatrix[x, y] + " ";
            }
            Debug.Log(rowString);
        }
    }
}



