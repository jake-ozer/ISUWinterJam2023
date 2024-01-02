using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StructureGeneratorWithPresets : MonoBehaviour
{
    //corresoonds (as a square) to the box determining how many chunks will be generated
    [SerializeField] private float boundingSize;
    //chunk size also as a square
    [SerializeField] private float chunkSize;
    //list to store all nodes created (so we can iterate through them as needed)
    private List<Node> nodes;
    //structures to spawn
    //[SerializeField] private List<GameObject> structures;
    public GameObject structure;

    public GameObject SpawnStructure;
    public int spawnStructureLocationX;
    public int spawnStructureLocationY;

    private void Awake()
    {
        nodes = new List<Node>();
        GenerateGrid();
        SpawnPresetStructure();
        SpawnStrcuturesOnGrid();
    }

    private void GenerateGrid()
    {
        float startX = 0;
        float startY = 0;

        for (float x = startX; x < boundingSize; x += chunkSize)
        {
            for (float y = startY; y < boundingSize; y += chunkSize)
            {
                Node newNode = new Node(x, y);
                nodes.Add(newNode);
            }
        }
    }

    private void SpawnPresetStructure()
    {
        foreach (var node in nodes)
        {
            if (node.x == spawnStructureLocationX && node.y == spawnStructureLocationY)
            {
                Vector2 spawnLoc = new Vector2(node.x, node.y);
                Instantiate(SpawnStructure, spawnLoc, Quaternion.identity);
                node.used = true;
            }
        }
    }

    private void SpawnStrcuturesOnGrid()
    {
        foreach (var node in nodes)
        {
            if (node.used == false)
            {
                Vector2 spawnLoc = new Vector2(node.x, node.y);
                Instantiate(structure, spawnLoc, Quaternion.identity);
            }  
        }
    }

    private class Node
    {
        public float x;
        public float y;
        public bool used;

        public Node(float x, float y)
        {
            this.x = x;
            this.y = y;
        }

        public void MarkNodeAsUsed()
        {
            used = false;
        }
    }
}
