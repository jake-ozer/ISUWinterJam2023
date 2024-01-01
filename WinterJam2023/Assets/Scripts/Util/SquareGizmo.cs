using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareGizmo : MonoBehaviour
{
    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(1, 0, 0, 0.5f);
        Gizmos.DrawWireCube(transform.position, new Vector3(25, 25, 1));
    }

}
