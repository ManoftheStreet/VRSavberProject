using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class Spawner : MonoBehaviour
{
    //public GameObject[] cubes;
    public Transform[] points;
    public float beat = 1f;
    float timer;
    public GameObject killZone;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > beat)
        {
            timer -= beat;

            /*GameObject c = Instantiate(cubes[Random.Range(0, cubes.Length)], points[Random.Range(0, points.Length)]);
            c.transform.localPosition = Vector3.zero;
            c.transform.Rotate(transform.forward, 90 * Random.Range(0, points.Length));*/
            Spawn();
        }

    }
    void Spawn()
    {
        int randomIndex = Random.Range(0, GameManager.Instance.pool.prefabs.Length);
        GameObject cube = GameManager.Instance.pool.Get(randomIndex);

        Transform randomPoint = points[Random.Range(0, points.Length)];
        cube.transform.position = randomPoint.position;
 
        // �÷��̾ ���ϴ� ������ ����մϴ�.
        Vector3 directionToPlayer = (killZone.transform.position - cube.transform.position).normalized;

        // Cube�� ������ �÷��̾� ������ ȸ����ŵ�ϴ�.
        cube.transform.rotation = Quaternion.LookRotation(directionToPlayer);
        cube.transform.Rotate(transform.forward, 90 * Random.Range(0, points.Length));
        cube.transform.SetParent(this.transform);
    }
}
