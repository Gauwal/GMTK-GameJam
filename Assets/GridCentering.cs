using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridCentering : MonoBehaviour
{
    [SerializeField] private TilemapGridGenerator TMgene;

    private void Awake()
    {
        transform.position = TMgene.GetCellAtPosition(transform.position);
    }
}
