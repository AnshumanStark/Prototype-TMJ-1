using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFolloe : MonoBehaviour
{
    [SerializeField] private Transform target = null;

    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - target.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, target.position + offset, Time.deltaTime * 3); 
    }
}