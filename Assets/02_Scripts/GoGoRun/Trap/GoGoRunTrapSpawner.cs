using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class GoGoRunTrapSpawner : ObstaclePool
{
    public GoGoRunManager manager;

    private Coroutine co_StartSpawn;

    private Coroutine co_SpawnSaw;
    private Coroutine co_SpawnFire;
    private Coroutine co_SpawnSpike;
    private Coroutine co_SpawnSpikeBall;
    private Coroutine co_SpawnSpikeHead;
    private Coroutine co_SpawnTrampoline;

    private bool isStart = false;
    private float cool = 3f;


    private IEnumerator Start()
    {
        yield return new WaitUntil(() => GameManager.Instance.curMiniGameScript != null);
        GameManager.Instance.curMiniGameScript.OnStart += StartSpawn;
        GameManager.Instance.curMiniGameScript.OnPause += StopAllSpawn;

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
        Spawn();
        yield break;
    }


    private void Spawn()
    {
        if(co_SpawnSaw != null)
            StopCoroutine(co_SpawnSaw);

        if (co_SpawnFire != null)
            StopCoroutine(co_SpawnFire);

        if (co_SpawnSpike != null)
            StopCoroutine(co_SpawnSpike);

        if (co_SpawnSpikeBall != null)
            StopCoroutine(co_SpawnSpikeBall);

        if (co_SpawnSpikeHead != null)
            StopCoroutine(co_SpawnSpikeHead);

        if (co_SpawnTrampoline != null)
            StopCoroutine(co_SpawnTrampoline);

        co_SpawnSaw = StartCoroutine(CoSpawnSaw());
        co_SpawnFire = StartCoroutine(CoSpawnFire());
        co_SpawnSpike = StartCoroutine(CoSpawnSpike());
        co_SpawnSpikeBall = StartCoroutine(CoSpawnSpikeBall());
        co_SpawnSpikeHead = StartCoroutine(CoSpawnSpikeHead());
        co_SpawnTrampoline = StartCoroutine(CoSpawnTrampoline());
    }

    private void StopAllSpawn()
    {
        if (co_SpawnSaw != null)
            StopCoroutine(co_SpawnSaw);

        if (co_SpawnFire != null)
            StopCoroutine(co_SpawnFire);

        if (co_SpawnSpike != null)
            StopCoroutine(co_SpawnSpike);

        if (co_SpawnSpikeBall != null)
            StopCoroutine(co_SpawnSpikeBall);

        if (co_SpawnSpikeHead != null)
            StopCoroutine(co_SpawnSpikeHead);

        if (co_SpawnTrampoline != null)
            StopCoroutine(co_SpawnTrampoline);
    }

    private IEnumerator CoSpawnSaw()
    {
        // -2.5f ~ -3.5f
        while (isStart)
        {
            int waitTime = Random.Range(5, 8);
            yield return CoroutineHelper.WaitForSeconds(waitTime);
            GameObject go = SpawnFromPool("Saw");
            go.transform.position = new Vector3(10, Random.Range
                (-3.5f, -2.6f), 0);
        }
        yield break;
    }


    private IEnumerator CoSpawnFire()
    {
        while(isStart)
        {
            int waitTime = Random.Range(8, 15);
            yield return CoroutineHelper.WaitForSeconds(waitTime);
            GameObject go = SpawnFromPool("Fire");
            go.transform.position = new Vector3(15, go.transform.position.y, 0);
        }
        yield break;
    }


    private IEnumerator CoSpawnSpike()
    {
        while (isStart)
        {
            int waitTime = Random.Range(5, 10);
            yield return CoroutineHelper.WaitForSeconds(waitTime);
            GameObject go = SpawnFromPool("Spike");
            go.transform.position = new Vector3(20, go.transform.position.y, 0);
        }
        yield break;
    }


    private IEnumerator CoSpawnSpikeBall()
    {
        yield return null;
    }


    private IEnumerator CoSpawnSpikeHead()
    {
        while (isStart)
        {
            int waitTime = Random.Range(10, 20);
            yield return CoroutineHelper.WaitForSeconds(waitTime);
            GameObject go = SpawnFromPool("SpikeHead");
            go.transform.position = new Vector3(13, go.transform.position.y, 0);
        }
        yield break;
    }


    private IEnumerator CoSpawnTrampoline()
    {
        while (isStart)
        {
            int waitTime = Random.Range(5, 15);
            yield return CoroutineHelper.WaitForSeconds(waitTime);
            GameObject go = SpawnFromPool("TramPoline");
            go.transform.position = new Vector3(20, -3.5f, 0);
        }
        yield break;
    }
}
