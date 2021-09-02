using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


public class GridManager : MonoBehaviour
{
   [SerializeField] private int width, height;
   [SerializeField] private Tile tilePrefab;
   [SerializeField] private Transform cam;
   [SerializeField] private Transform tilesParent;

   private void Start()
   {
      GenerateGrid();
   }

   void GenerateGrid()
   {
      for (int x = 0; x < width; x++)
      {
         for (int y = 0; y < height; y++)
         {
            var spawnerTile = Instantiate(tilePrefab, new Vector3(x+.5f, y), Quaternion.identity, tilesParent);
            spawnerTile.name = $"Tile {x} {y}";

            var isOffset = (x % 2 == 0 && y % 2 != 0) || (x % 2 != 0 && y % 2 == 0);
            spawnerTile.Init(isOffset);
         }
      }

      cam.transform.position = new Vector3((float) width / 2 - 0.5f, (float) height / 2 - 0.5f, -10);
   }
}
