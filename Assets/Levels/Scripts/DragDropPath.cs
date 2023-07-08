using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragDropPath : MonoBehaviour
{
    Vector3 mouseOffset;
    [SerializeField] TilemapGridGenerator TMgenerator;
    [SerializeField] private int maxPath;
    [SerializeField] private Transform selector;
    [SerializeField] private GameObject[] PathBlocks;
    private List<Vector3> path_placed;
    private Vector3 PosInGrid;
    private int numberPath;
    private Vector3 currPos;
    private bool selected = false;

    private GhostMove movement;

    private int phase=1;
    public void SetPhase(int i) { phase = i; }
    private void Awake()
    {
        path_placed = new List<Vector3>();
        numberPath = 0;
        currPos = TMgenerator.WorldToGrid(TMgenerator.GetCellAtPosition(transform.position));

        movement = GetComponent<GhostMove>();
    }
    private Vector3 GetMouseWorldPosition()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
    private void OnMouseDown()
    {
        mouseOffset = gameObject.transform.position - GetMouseWorldPosition();
        if (phase == 2)
        {
            if (!selected)
            {
                currPos = TMgenerator.WorldToGrid(TMgenerator.GetCellAtPosition(GetMouseWorldPosition() + mouseOffset));
                selector.GetComponent<SpriteRenderer>().enabled = true;
                selector.position = transform.position;
                selected = true;
            }
            else
            {
                currPos = TMgenerator.WorldToGrid(TMgenerator.GetCellAtPosition(GetMouseWorldPosition() + mouseOffset));
                selector.GetComponent<SpriteRenderer>().enabled = false;
                selected = false;
                foreach (GameObject pathBlock in PathBlocks)
                {
                    pathBlock.GetComponent<SpriteRenderer>().enabled = false;
                }
                numberPath = 0;
                path_placed = new List<Vector3>();
            }
        }
    }
    private void OnMouseDrag()
    {
        Vector3 positionGrid = TMgenerator.WorldToGrid(TMgenerator.GetCellAtPosition(GetMouseWorldPosition() + mouseOffset));
        if (phase == 1 && TMgenerator.IsCellValid(positionGrid)) { transform.position = TMgenerator.GetPositionInCell(positionGrid);}
        
        
        PosInGrid = TMgenerator.WorldToGrid(TMgenerator.GetCellAtPosition(GetMouseWorldPosition() + mouseOffset));
        
        if (!path_placed.Contains(PosInGrid) && numberPath < maxPath && TMgenerator.IsCellValid(PosInGrid)&& (currPos-PosInGrid).magnitude<=1 && selected && phase==2)
        {
            path_placed.Add(PosInGrid);
            PathBlocks[numberPath].GetComponent<SpriteRenderer>().enabled = true;
            PathBlocks[numberPath].transform.position = TMgenerator.GetPositionInCell( PosInGrid);
            numberPath += 1;
            currPos = PosInGrid;
        }

    }

    public void MoveAlongPath()
    {
        currPos = transform.position;
        Vector3 direction;
        
        for (int i = 0; i < maxPath; i++)
        {
            direction = (path_placed[i] - currPos);
            Debug.Log(direction);
            while (!movement.Time_To_Move())
            {
                StartCoroutine(MoveWithDelay());
            }
            movement.Move(new Vector2Int((int)direction.x, (int)direction.y));
        }
    }

    IEnumerator MoveWithDelay()
    {
        yield return new WaitForSeconds(0.1f); // Wait for 1 second before moving

        
    }

}