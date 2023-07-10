using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] cubes;
    public Transform[] points;
    public float beat = 1f;
    float timer;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > beat)
        {
            timer -= beat;

            GameObject c = Instantiate(cubes[Random.Range(0, cubes.Length)], points[Random.Range(0, points.Length)]);
            c.transform.localPosition = Vector3.zero;
            c.transform.Rotate(transform.forward, 90 * Random.Range(0, points.Length));

            
        }

    }
}
