using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MinigameBoard : MonoBehaviour {

    //grid variables
    [SerializeField]
    private int rows;
    [SerializeField]
    private int cols;
    [SerializeField]
    private Vector2 gridSize;
    [SerializeField]
    private Vector2 gridOffset;
    [SerializeField]
    private float cellScalar;

    //cell variables
    [SerializeField]
    private Sprite cellSprite;

    private Vector2 cellSize;
    private Vector2 cellScale;
    


    // Use this for initialization
    void Start () {
        InitializeCells();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void InitializeCells()
    {
        GameObject cellObject = new GameObject();
        //create empty object and add image component
        cellObject.AddComponent<Image>().sprite = cellSprite;

        //store original sprite size
        cellSize = cellSprite.bounds.size;

        //get new cell size
        Vector2 newCellSize = new Vector2(gridSize.x / (float)cols, gridSize.y / (float)rows);

        cellScale.x = (newCellSize.x / cellSize.x) * cellScalar;
        cellScale.y = (newCellSize.y / cellSize.y) * cellScalar;

        cellSize = newCellSize; //set new size

        cellObject.GetComponent<RectTransform>().sizeDelta = new Vector2(cellScale.x, cellScale.y);

        //apply cell offset
        gridOffset.x = -(gridSize.x / 2) + cellSize.x / 2;
        gridOffset.y = -(gridSize.y / 2) + cellSize.y / 2;

        //fill grid with cells
        for(int row = 0; row < rows; row++)
        {
            for(int col = 0; col < cols; col++)
            {
                Vector2 pos = new Vector2(col * cellSize.x + gridOffset.x + transform.position.x, row * cellSize.y + gridOffset.y + transform.position.y);
                GameObject c0 = Instantiate(cellObject, pos, Quaternion.identity) as GameObject;
                c0.transform.SetParent(transform, false);               
            }
        }

    }

    void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, gridSize);
    }


}
