//Should be attached to door in hallway

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomGenerator : MonoBehaviour
{
    public GameObject floor;
    public GameObject ceiling;
    public GameObject wall1;
    public GameObject wall2; // Needs windows
    public GameObject wall3;
    public GameObject wall4; // Needs doors

    public GameObject key;
    public GameObject door;
    public GameObject cabinet;
    public GameObject chair;
    public GameObject table;
    public GameObject cart;
    public GameObject teacherDesk;
    public GameObject poster;
    public GameObject ceilingLight;
    public GameObject lightSwitch;
    public GameObject trashCan;
    public GameObject recycleBin1;
    public GameObject recycleBin2;
   
    public float width;
    public float depth;
    public float height;
    public int rows;
    public int columns;

    void Start()
    {
        rows = Random.Range(4,7);
        columns = Random.Range(3,6);
        height = Random.Range(13,18);
        width = rows*10;
        depth = columns*10;
        roomSizing();
        
        placeObject(recycleBin1,1,columns,-8,-1,1.8f,0);
        placeObject(recycleBin2,1,columns,-7,-1,0,0);
        placeObject(trashCan,1,columns,-6,-1,0,0);
        
//      placeObject(cart,rows-2,columns-2,0,0,0,0);

        for(int j=1; j<=columns; j++){
            for (int i=2; i<rows; i++){
                placeObject(table,i,j,-5,-5,0,0);
                placeObject(chair,i,j,-5,-5,0,0);
            }
        }
        int cabCount=Random.Range(1,columns);
        Debug.Log(cabCount);
        for(int cab=1;cab<=columns; cab++){
            if(cab<=cabCount){
                placeObject(cabinet,rows,cab,0,-9,0,90);
            }else{
                placeObject(table,rows,cab,-5,-5,0,0);
                placeObject(chair,rows,cab,-5,-5,0,0);
            }
        }
        
        int doorPos = Random.Range(-columns/2+1,columns/2);
        door.transform.position = new Vector3 (-width/2,door.transform.position.y,doorPos*10);


        for(int k=1; k<=columns; k++){
            for (int l=1; l<=rows; l++){
                placeObject(ceilingLight,l,k,-5,-5,height-1.38f,0);
            }
        }
    }
    

    public void roomSizing(){
        // Scales and places floor, ceiling, walls
        Vector3 size= new Vector3(width,1,depth);
        floor.transform.localScale = size;
        ceiling.transform.localScale = size;
        ceiling.transform.position = new Vector3(ceiling.transform.position.x,height,ceiling.transform.position.z);
        wall1.transform.position = new Vector3(wall1.transform.position.x, height/2,-depth/2);
        wall1.transform.localScale = new Vector3(width,1,height);
        wall3.transform.position = new Vector3(wall3.transform.position.x, height/2,depth/2);
        wall3.transform.localScale = new Vector3(width,1,height);
        wall2.transform.position = new Vector3(width/2, height/2,wall2.transform.position.z);
        wall2.transform.localScale = new Vector3(depth,1,height);
        wall4.transform.position = new Vector3(-width/2, height/2,wall4.transform.position.z);
        wall4.transform.localScale = new Vector3(depth,1,height);
    }
    
    public void placeObject(GameObject obid, int row, int col, float rowSub, float colSub, float y, float yRot){
        float x = (-width/2+((width/rows)*row))+rowSub;
        float z = (-depth/2+((depth/columns)*col))+colSub;
        GameObject go = Instantiate(obid, new Vector3(x,y,z), Quaternion.Euler(-90,yRot,0)) as GameObject;
        go.transform.parent = GameObject.Find("Structures").transform;
        go.transform.localScale = new Vector3(1,1,1);
    }
}