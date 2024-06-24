using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoGoRunTrapSpawner : ObstaclePool
{
    public GoGoRunManager manager;

    private Coroutine co_StartSpawn;

    private bool isStart = false;
    private float cool = 3f;

    private void OnEnable()
    {
        manager.onGameStart += StartSpawn;
    }

    private void OnDisable()
    {
        manager.onGameStart -= StartSpawn;
    }
    private void StartSpawn()
    {
        isStart = true;
        if (co_StartSpawn != null)
        {
            StopCoroutine(co_StartSpawn);
        }

        co_StartSpawn = StartCoroutine(CoStartSpawn());
    }

    private IEnumerator CoStartSpawn()
    {
        while(isStart)
        {
            
            yield return CoroutineHelper.WaitForSeconds(cool);
        }

        yield break;
    }
    public bool Destory(GameObject go)
    {
        if (PoolDictionary.ContainsKey(go.name))
        {
            go.SetActive(false);
            PoolDictionary[go.name].Enqueue(go);
            return true;
        }
        return false;
    }
}
