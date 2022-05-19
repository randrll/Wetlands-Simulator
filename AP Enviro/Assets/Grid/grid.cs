using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grid // classic class
{
    private int width;
    private int height;
    private int[,] gridMap;

    public grid(int width, int height) {
        this.width = width;
        this.height = height;

        gridMap = new int[width, height];

        Debug.Log("Grid created with a height of " + height + " and a width of " + width);
    }

    public void printGrid() {
        for (int r = 0; r < gridMap.GetLength(0); r++) {
            for (int c = 0; c < gridMap.GetLength(1); c++) {
                Debug.Log(r + " " + c);
            }
        }
    }
}
