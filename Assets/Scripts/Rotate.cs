using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField]
    private float Speed = 2f;
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, Speed*Time.deltaTime);
    }
}
