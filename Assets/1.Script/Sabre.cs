using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sabre : MonoBehaviour
{
    public LayerMask layer;
    public ParticleSystem red;
    public ParticleSystem blue;
    public AudioClip shoot;

    public AudioSource audio;
    Vector3 prevPos;

    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;

        if(Physics.Raycast(transform.position,transform.forward,out hit, 1.2f , layer))
        {
            if (Vector3.Angle(transform.position - prevPos, hit.transform.up) > 130)
            {
                Cube cube = hit.transform.GetComponent<Cube>();

                if(cube != null)
                {
                    Effect(hit.collider.gameObject.layer, hit.transform.position);
                    audio.PlayOneShot(shoot);
                    cube.transform.position = new Vector3(0, 10, 0);
                    cube.gameObject.SetActive(false);
                    
                }
            }
        }

        prevPos = transform.position;
    }

    public void Effect(int layer, Vector3 position)
    {
        if (layer == 6) // 6번 레이어에 해당하는 경우 (예: Red)
        {
            if (red != null)
            {
                // 파티클 이펙트 재생
                red.transform.position = position;
                red.Play();
            }
        }
        else if (layer == 7) // 7번 레이어에 해당하는 경우 (예: Blue)
        {
            if (blue != null)
            {
                // 파티클 이펙트 재생
                blue.transform.position = position;
                blue.Play();
            }
        }
    }
}
