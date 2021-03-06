using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamCode : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, target.position + offset, Time.deltaTime*5);
    }
}
