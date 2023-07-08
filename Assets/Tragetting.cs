using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tragetting : MonoBehaviour
{
    [SerializeField] private TilemapGridGenerator TMgene;
    [SerializeField] private Transform[] players;
    [SerializeField] private Transform[] coins;
    private int[,] weigthMatrix;
    private void Awake()
    {

        weigthMatrix = new int[(int)TMgene.getSize().x, (int)TMgene.getSize().x];
    }
    public void moveTagret()
    {
        float value = 0;
        Vector2 Pos;
        for (int i = 0; i< TMgene.getSize().x; i++)
        {
            value = 0;
            for (int j  = 0; j < TMgene.getSize().x; j++)
            {
                foreach (Transform player in players)
                {
                    Pos = (TMgene.WorldToGrid(TMgene.GetCellAtPosition(player.position)));
                    value += (Mathf.Abs(Pos.x - i) + Mathf.Abs(Pos.y - j));//big distance good
                }
                foreach (Transform coin in coins)
                {
                    Pos = (TMgene.WorldToGrid(TMgene.GetCellAtPosition(coin.position)));
                    value -= (Mathf.Abs(Pos.x - i) + Mathf.Abs(Pos.y - j)) * 10f / coins.Length;//small distnce good
                }
            }
        }

        int maxVal = int.MinValue;
        Vector2Int BestPos=new Vector2Int();
        for (int i = 0; i < TMgene.getSize().x; i++)
        {
            for (int j = 0; j < TMgene.getSize().x; j++)
            {
                if (weigthMatrix[i,j] > maxVal)
                {
                    maxVal = weigthMatrix[i, j];
                    BestPos = new Vector2Int(i, j);
                }

            }
        }

        transform.position = TMgene.GetPositionInCell((Vector2)BestPos);
    }
    
}
