using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class StructureGenerator : MonoBehaviour
{
    //corresoonds (as a square) to the box determining how many chunks will be generated
    [SerializeField] private float boundingSize;
    //chunk size also as a square
    [SerializeField] private float chunkSize;
    public int startCoordX = 3;
    public int startCoordY = 3;
    //list to store all nodes created (so we can iterate through them as needed)
    private List<Node> nodes;
    //structures to spawn
    //[SerializeField] private List<GameObject> structures;
    //public GameObject structure;
    public GameObject floorTexture;

    //GENERATION REFERENCE LISTS
    public List<GameObject> enemyEncounters;
    public List<GameObject> pickups;
    public List<GameObject> decorations;
    public GameObject crystalStrcuture;

    //GENERATION FIELDS (Numbers will be guarenteed, but randomized on location and type)
    public int numEnemyEn;
    public int numPickups;
    public int numCrystals;
    public int numDec;

    private void Awake()
    {
        nodes = new List<Node>();
        GenerateGrid();
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

                if (x == (startCoordX*chunkSize) && y == (startCoordY*chunkSize))
                {
                    newNode.startSpot = true;
                }
            }
        }
    }

    private void SpawnStrcuturesOnGrid()
    {
        List<Node> usedEnEnNodes = new List<Node>();
        List<Node> usedPickupNodes = new List<Node>();
        List<Node> usedCrystalNodes = new List<Node>();
        List<Node> usedDecNodes = new List<Node>();

        //generate floortextures across all nodes
        foreach (var node in nodes)
        {
            Vector2 spawnLoc = new Vector2(node.x, node.y);
            Instantiate(floorTexture, spawnLoc, Quaternion.identity);
        }

        //randomly assign structures to nodes 

        //assigning crystal spots
        for (int i = 0; i < numCrystals; i++)
        {
            int randomNodeIndex = Random.Range(0, nodes.Count);

            while (usedCrystalNodes.Contains(nodes[randomNodeIndex]) || nodes[randomNodeIndex].startSpot)
            {
                randomNodeIndex = Random.Range(0, nodes.Count);
            }

            usedCrystalNodes.Add(nodes[randomNodeIndex]);
            Vector2 spawnLoc = new Vector2(nodes[randomNodeIndex].x, nodes[randomNodeIndex].y);
            //pick a random enemy encounter to place
            Instantiate(crystalStrcuture, spawnLoc, Quaternion.identity);
        }

        //assigning enemy encounters
        for (int i = 0; i < numEnemyEn; i++)
        {
            int randomNodeIndex = Random.Range(0, nodes.Count);

            while (usedEnEnNodes.Contains(nodes[randomNodeIndex]) || nodes[randomNodeIndex].startSpot)
            {
                randomNodeIndex = Random.Range(0, nodes.Count);
            }

            usedEnEnNodes.Add(nodes[randomNodeIndex]);
            Vector2 spawnLoc = new Vector2(nodes[randomNodeIndex].x, nodes[randomNodeIndex].y);
            //pick a random enemy encounter to place
            int randomEnemyEnIndex = Random.Range(0, enemyEncounters.Count);
            GameObject encounter = enemyEncounters[randomEnemyEnIndex];
            Instantiate(encounter, spawnLoc, Quaternion.identity);
        }

        //assigning pickup encounters
        for (int i = 0; i < numEnemyEn; i++)
        {
            int randomNodeIndex = Random.Range(0, nodes.Count);

            while (usedPickupNodes.Contains(nodes[randomNodeIndex]) || nodes[randomNodeIndex].startSpot)
            {
                randomNodeIndex = Random.Range(0, nodes.Count);
            }

            usedPickupNodes.Add(nodes[randomNodeIndex]);
            Vector2 spawnLoc = new Vector2(nodes[randomNodeIndex].x, nodes[randomNodeIndex].y);
            //pick a random enemy encounter to place
            int randomPickupIndex = Random.Range(0, pickups.Count);
            GameObject pickup = pickups[randomPickupIndex];
            Instantiate(pickup, spawnLoc, Quaternion.identity);
        }

        //assigning decorations
        for (int i = 0; i < numDec; i++)
        {
            int randomNodeIndex = Random.Range(0, nodes.Count);

            while (usedDecNodes.Contains(nodes[randomNodeIndex]) || nodes[randomNodeIndex].startSpot)
            {
                randomNodeIndex = Random.Range(0, nodes.Count);
            }

            usedDecNodes.Add(nodes[randomNodeIndex]);
            Vector2 spawnLoc = new Vector2(nodes[randomNodeIndex].x, nodes[randomNodeIndex].y);
            //pick a random enemy encounter to place
            int randomDecIndex = Random.Range(0, decorations.Count);
            GameObject dec = decorations[randomDecIndex];
            Instantiate(dec, spawnLoc, Quaternion.identity);
        }
    }

    private class Node
    {
        public float x;
        public float y;
        public bool enEnUsed;
        public bool pickupUsed;
        public bool startSpot;

        public Node(float x, float y)
        {
            this.x = x;
            this.y = y;
        }
    }
}
