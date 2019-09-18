using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public Vector3 position;
    public bool isPassable;

    public List<Node> myNeighbours;
}
