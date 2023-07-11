using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    //.. ������ ������
    public GameObject[] prefabs;

    //.. Ǯ ����� �ϴ� ����Ʈ��
    List<GameObject>[] pools;

    private void Awake()
    {
        pools = new List<GameObject>[prefabs.Length];

        for (int index = 0; index < pools.Length; index++)
        {
            pools[index] = new List<GameObject>();
        }
    }

    public GameObject Get(int index)
    {
        GameObject select = null;
        //...������ Ǯ�� ��� �ִ� ���ӿ�����Ʈ ����
        //... �߰��ϸ� select ������ �Ҵ��ϵ���
        foreach (GameObject item in pools[index])
        {
            if (!item.activeSelf)
            {
                //..�߰ߵǸ� seslect ������ �Ҵ�
                select = item;
                select.SetActive(true);
                break;
            }
        }
        //... ��� ��� �Ǿ��ٸ� 
        if (!select)
        {
            //... ���Ӱ� �����ϰ�  select ������ �Ҵ�
            select = Instantiate(prefabs[index], transform);
            //...�׸��� Ǯ�� �����
            pools[index].Add(select);
        }

        return select;
    }
  /*  public void ReturnToPool(GameObject obj, int index)
    {
        Debug.Log("Returning object to pool: " + obj.name);
        obj.SetActive(false);
        pools[index].Add(obj);
    }*/
}