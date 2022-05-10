using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public List<Transform> nodes = new List<Transform>();
    public float speed;
    int currentNode = 0;
    public float distance;

    Vector3 targetDir = Vector3.zero;
    void Update()
    {
        if (currentNode < nodes.Count)
        {
            targetDir = nodes[currentNode].position - transform.position;
            distance = Vector3.Distance(transform.position, nodes[currentNode].position);
            transform.Translate(targetDir.normalized * speed * Time.deltaTime);
            if (distance <= 6f)
            {
                currentNode++;
            }
        }
        
    }
}
