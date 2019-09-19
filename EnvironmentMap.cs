using UnityEngine;

public class EnvironmentMap : MonoBehaviour
{

    public GameObject tilePrefab;
    public GameObject fenceEdgePrefab;
    public GameObject fenceWallPrefab;
    public GameObject fencePolePrefab;
    public GameObject fenceEdgeEndPrefab;
    public BoxCollider2D boxCollider;
    GameObject tilesGroup;
    GameObject fenceGroup;
    GameObject boxColliderGroup;
    int mapWidth = 11; //must be >= 3
    int mapHeight = 11; //must be >= 3

    // Start is called before the first frame update
    void Start()
    {
        tilesGroup = new GameObject("Tiles");
        fenceGroup = new GameObject("Fences");
        boxColliderGroup = new GameObject("BoxColliders");
        
        tilesGroup.transform.parent = transform;
        fenceGroup.transform.parent = transform;
        boxColliderGroup.transform.parent = transform;
        
        generateTileMap();
    }

    // Update is called once per frame

    void generateTileMap(){
        for(int y = 0; y < mapHeight; y++){
            for(int x = 0; x < mapWidth; x++){
                //Platform tiles
                GameObject tempGo = Instantiate(tilePrefab);
                tempGo.transform.position = new Vector3(-3 + x, -4 + y);

                tempGo.transform.parent = tilesGroup.transform;

                if(y == 0){ //fence at the bottom
                    if(x != mapWidth - 1 && x % 3 == 0){
                        GameObject fenceEdgeGo = Instantiate(fenceEdgePrefab);
                        fenceEdgeGo.transform.position = new Vector3(-3 + x, -4 + y);
                        GameObject fenceGo = Instantiate(fenceWallPrefab);
                        fenceGo.transform.position = new Vector3(-2.5f + x, -4 + y);

                        fenceEdgeGo.transform.parent = fenceGroup.transform;
                        fenceGo.transform.parent = fenceGroup.transform;

                    } else if(x != mapWidth - 1 && x % 3 != 0){
                        GameObject fenceGo = Instantiate(fenceWallPrefab);
                        fenceGo.transform.position = new Vector3(-3 + x, -4 + y);
                        GameObject fenceGo1 = Instantiate(fenceWallPrefab);
                        fenceGo1.transform.position = new Vector3(-2.5f + x, -4 + y);

                        fenceGo.transform.parent = fenceGroup.transform;
                        fenceGo1.transform.parent = fenceGroup.transform;

                        if(x < mapWidth - 2){
                            GameObject fenceGo2 = Instantiate(fenceWallPrefab);
                            fenceGo2.transform.position = new Vector3(-2 + x, -4 + y);

                            fenceGo2.transform.parent = fenceGroup.transform;
                        }                        
                    } else if(x == mapWidth - 1){
                        GameObject fenceEndEdge = Instantiate(fenceEdgeEndPrefab);
                        fenceEndEdge.transform.position = new Vector3(-3 + x, -4 + y);
                        
                        fenceEndEdge.transform.parent = fenceGroup.transform;
                    }
                }
                if(y == mapHeight - 1){ //fence at the top
                    if(x != mapWidth - 1 && x % 3 == 0){
                        GameObject fenceEdgeGo = Instantiate(fenceEdgePrefab);
                        fenceEdgeGo.transform.position = new Vector3(-3 + x, -4 + y);
                        GameObject fenceGo = Instantiate(fenceWallPrefab);
                        fenceGo.transform.position = new Vector3(-2.5f + x, -4 + y);

                        fenceEdgeGo.transform.parent = fenceGroup.transform;
                        fenceGo.transform.parent = fenceGroup.transform;

                    } else if(x != mapWidth - 1 && x % 3 != 0){
                        GameObject fenceGo = Instantiate(fenceWallPrefab);
                        fenceGo.transform.position = new Vector3(-3 + x, -4 + y);
                        GameObject fenceGo1 = Instantiate(fenceWallPrefab);
                        fenceGo1.transform.position = new Vector3(-2.5f + x, -4 + y);

                        fenceGo.transform.parent = fenceGroup.transform;
                        fenceGo1.transform.parent = fenceGroup.transform;
                        if(x < mapWidth - 2){
                            GameObject fenceGo2 = Instantiate(fenceWallPrefab);
                            fenceGo2.transform.position = new Vector3(-2 + x, -4 + y);

                            fenceGo2.transform.parent = fenceGroup.transform;
                        }
                    } else if(x == mapWidth - 1){
                        GameObject fenceEndEdge = Instantiate(fenceEdgeEndPrefab);
                        fenceEndEdge.transform.position = new Vector3(-3 + x, -4 + y);
                        
                        fenceEndEdge.transform.parent = fenceGroup.transform;
                    }
                }

                if(x == 0 && y != 0){ //fence at the left
                    GameObject fencePole = Instantiate(fencePolePrefab);
                    fencePole.transform.position = new Vector3(-3 + x, -4 + y);
                    GameObject fencePole1 = Instantiate(fencePolePrefab);
                    fencePole1.transform.position = new Vector3(-3 + x, -4.5f + y);

                    fencePole.transform.parent = fenceGroup.transform;
                    fencePole1.transform.parent = fenceGroup.transform;
                }
                if(x == mapWidth - 1 && y != 0){ //fence at the right
                    GameObject fencePole = Instantiate(fencePolePrefab);
                    fencePole.transform.position = new Vector3(-3 + x, -4 + y);
                    GameObject fencePole1 = Instantiate(fencePolePrefab);
                    fencePole1.transform.position = new Vector3(-3 + x, -4.5f + y);

                    fencePole.transform.parent = fenceGroup.transform;
                    fencePole1.transform.parent = fenceGroup.transform;
                }



            }
        }

            //fence boxCollider at the bottom
            BoxCollider2D tempCollider1 = Instantiate(boxCollider);
            tempCollider1.transform.position = new Vector3(-3 + mapWidth / 2, -4 + 0);
            tempCollider1.transform.localScale = new Vector3(mapWidth,0.3f);
            
            //fence boxCollider at the top
            BoxCollider2D tempCollider2 = Instantiate(boxCollider);
            tempCollider2.transform.position = new Vector3(-3 + mapWidth / 2, -4 + mapHeight - 1);
            tempCollider2.transform.localScale = new Vector3(mapWidth,0.3f);
            
            //fence boxCollider at the left
            BoxCollider2D tempCollider3 = Instantiate(boxCollider);
            tempCollider3.transform.position = new Vector3(-3 + 0, -4 + mapHeight / 2);
            tempCollider3.transform.localScale = new Vector3(0.3f, mapHeight);
            
            //fence boxCollider at the right
            BoxCollider2D tempCollider4 = Instantiate(boxCollider);
            tempCollider4.transform.position = new Vector3(-3 + mapWidth - 1, -4 + mapHeight / 2);
            tempCollider4.transform.localScale = new Vector3(0.3f, mapHeight);
            
            tempCollider1.transform.parent = boxColliderGroup.transform;
            tempCollider2.transform.parent = boxColliderGroup.transform;
            tempCollider3.transform.parent = boxColliderGroup.transform;
            tempCollider4.transform.parent = boxColliderGroup.transform;
    }
    void Update()
    {
        
    }
}
