using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickableTile : MonoBehaviour
{

    public int tileX;
    public int tileY;
    public int tileZ;
    public CustomTileMap3D map;

    void OnMouseUp()
    {
        Debug.Log("Click");

        map.MoveSelectedUnitTo(tileX, tileY, tileZ);
    }


}
