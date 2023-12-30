using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ally : MonoBehaviour
{
    public bool followingPlayer = true;
    [SerializeField] private AIDestinationSetter aiDes;
    [SerializeField] private AIPath aiPath;
    private GameObject player;

    private void Awake()
    {
        player = GameObject.Find("Player");
    }

    //*****NPCAggro handles targeting for attack state*******
    private void Update()
    {
        if (followingPlayer)
        {
            aiDes.target = player.transform;
            aiPath.endReachedDistance = 2.52f;
            //make settings for following
        }
        else
        {
            aiPath.endReachedDistance = 0;
        }
    }

}
