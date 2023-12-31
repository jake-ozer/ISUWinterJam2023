using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ally : MonoBehaviour
{
    public bool followingPlayer = true;
    [SerializeField] private AIDestinationSetter aiDes;
    [SerializeField] private AIPath aiPath;
    [SerializeField] private GameObject followBox;
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
            if (GetComponent<RangedEnemy>() != null)
            {
                GetComponent<RangedEnemy>().enabled = false;
            }
            followBox.SetActive(true);
        }
        else
        {  
            if (GetComponent<RangedEnemy>() != null)
            {
                GetComponent<RangedEnemy>().enabled = true;
                aiPath.endReachedDistance = 7.01f;
            }
            else
            {
                aiPath.endReachedDistance = 0;
            }
            followBox.SetActive(false);
        }
    }

}
