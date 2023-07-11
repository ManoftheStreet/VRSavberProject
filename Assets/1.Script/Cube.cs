using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public float speed = 5f;// Update is called once per frame
 

    void Update()
    {
        transform.position += Time.deltaTime * transform.forward * 5.0f;
    }
}
