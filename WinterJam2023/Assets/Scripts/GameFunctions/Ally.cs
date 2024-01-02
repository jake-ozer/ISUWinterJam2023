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
    [SerializeField] private GameObject npcAggro;
    private GameObject player;
    public float followSpeed = 5.3f;

    private void Awake()
    {
        player = GameObject.Find("Player");
    }

    //reset targeting collider
    private void OnEnable()
    {
        npcAggro.GetComponent<Collider2D>().enabled = false;
        npcAggro.GetComponent<Collider2D>().enabled = true;
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
            aiPath.maxSpeed = followSpeed;
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
            aiPath.maxSpeed = 2.57f;
        }
    }

}
