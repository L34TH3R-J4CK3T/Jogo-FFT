using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomTileMap3D : MonoBehaviour
{


    public GameObject selectedUnit;

    public TileType[] tileTypes;

    int[ , , ] tiles;
    
    int mapSizeX = 10;
    int mapSizeY = 10;
    int mapSizeZ = 10;



    // Start is called before the first frame update
    void Start()
    {   
        //Allocate our map tiles
        tiles = new int[mapSizeX,mapSizeY,mapSizeZ];

        //Initialize our map tiles
        for (int x = 0; x < mapSizeY; x++)
        {
            for (int y = 0; y < 1/* mapSizeY*/; y++)
            {
                for (int z = 0; z < mapSizeZ; z++)
                {
                tiles[x,y,z] = 0;
                }
            }
            
        }

        // Mountain

        tiles[4,0,4] = 2;
        tiles[5,0,4] = 2;
        tiles[6,0,4] = 2;
        tiles[7,0,4] = 2;
        tiles[8,0,4] = 2;

        tiles[4,0,5] = 2;
        tiles[4,0,6] = 2;
        tiles[8,0,5] = 2;
        tiles[8,0,6] = 2;

        //Spaw the Prefab
        GenerateMapVisual();


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GenerateMapVisual()
    {
        for (int x = 0; x < mapSizeY; x++)
        {
            for (int y = 0; y < 1/* mapSizeY*/; y++)
            {
                for (int z = 0; z < mapSizeZ; z++)
                {
                    TileType tt = tileTypes[tiles[x, y, z]];
                    GameObject go;
                    go = Instantiate( tt.tileVisualPrefab, new Vector3(x, y, z), Quaternion.identity );
                    ClickableTile ct = go.GetComponent<ClickableTile>();
                    ct.tileX = x;
                    ct.tileY = y;
                    ct.tileZ = z;
                    ct.map = this;
                     
                }
            }
            
        }
        
    }

    public Vector3 TileCoordToWorldCoord(int x, int y, int z) {
		return new Vector3(x, y, z);
	}

	public void MoveSelectedUnitTo(int x, int y, int z) {
		selectedUnit.GetComponent<Unit>().tileX = x;
		selectedUnit.GetComponent<Unit>().tileY = y;
        selectedUnit.GetComponent<Unit>().tileY = z;
		selectedUnit.transform.position = TileCoordToWorldCoord(x,y,z);
	}
}


