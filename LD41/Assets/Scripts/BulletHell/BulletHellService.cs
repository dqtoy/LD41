using System.Collections;
using System.Collections.Generic;
using LD41;
using UnityEngine;

public class BulletHellService : SingletonBehaviour<BulletHellService> {

    public UnityEngine.Events.UnityAction waitCallback;
    ObjectPooler objectPooler;

	private void Start()
	{
        objectPooler = ObjectPooler.Instance;
        //waitCallback += PlayerPattern1;
        //BulletHellUtil.CallFunctionAfterTime(1, waitCallback);
	}

    /*
    public void PlayerPattern1()
    {
        PlayPattern1(transform);
    }
    */
    public void PlayPattern0(Transform emitter)
    {
        StartCoroutine(EmitPattern0(emitter.position));
    }

    private IEnumerator EmitPattern0(Vector3 rootPosition)
    {
        int round = 3;
        int count = 10;
        float interval = 2;
        float dealtDegree = 360.0f / count;

        for (int i = 0; i < round; i++)
        {
            for (int j = 0; j < count; j++)
            {
                ObjectPooler.Instance.SpawnFromPool("NuclearBomb", rootPosition, new Vector3(dealtDegree * j, -90, 0));
            }
            yield return new WaitForSeconds(interval);
        }
    }


	public void PlayPattern1(Transform emitter)
    {
        StartCoroutine(EmitPattern1(emitter.position));
    }

    private IEnumerator EmitPattern1(Vector3 rootPosition)
    {
        int round = 3;
        int count = 10;
        float interval = 2;
        float dealtDegree = 360.0f / count;

        for (int i = 0; i < round; i++)
        {
            for (int j = 0; j < count; j++)
            {
                ObjectPooler.Instance.SpawnFromPool("NuclearBomb", rootPosition, new Vector3(dealtDegree * j, -90, 0));
            }
            yield return new WaitForSeconds(interval);
        }
    }

    public void PlayPattern2(Transform emitter)
    {
        StartCoroutine(EmitPattern2(emitter.position));
    }

    private IEnumerator EmitPattern2(Vector3 rootPosition)
    {
        int round = 3;
        int count = 10;
        float interval = 0.5f;
        float dealtDegree = 360.0f / count;
        float degreeOffset = -15.0f;

        for (int i = 0; i < round; i++)
        {
            degreeOffset += 15.0f;
            for (int j = 0; j < count; j++)
            {
                ObjectPooler.Instance.SpawnFromPool("NuclearBomb", rootPosition, new Vector3(dealtDegree * j + degreeOffset, -90, 0));
            }
            yield return new WaitForSeconds(interval);
        }
    }

    public void PlayPattern3(Transform emitter)
    {
        StartCoroutine(EmitPattern3(emitter.position));
    }

    private IEnumerator EmitPattern3(Vector3 rootPosition)
    {
        int round = 5;
        int count = 10;
        float interval = 0.5f;
        float dealtDegree = 360.0f / count;
        float degreeOffset = -15.0f;

        for (int i = 0; i < round; i++)
        {
            degreeOffset += 15.0f;
            for (int j = 0; j < count; j++)
            {
                ObjectPooler.Instance.SpawnFromPool("NuclearBomb_Slowdown", rootPosition, new Vector3(dealtDegree * j + degreeOffset, -90, 0));
            }
            yield return new WaitForSeconds(interval);
        }
    }


    public void PlayPattern4(Transform emitter)
    {
        StartCoroutine(EmitPattern4(emitter.position));
    }

    private IEnumerator EmitPattern4(Vector3 rootPosition)
    {
        int round = 5;
        int count = 10;
        float interval = 0.5f;
        float dealtDegree = 360.0f / count;
        float degreeOffset = -15.0f;

        for (int i = 0; i < round; i++)
        {
            degreeOffset += 15.0f;
            for (int j = 0; j < count; j++)
            {
                ObjectPooler.Instance.SpawnFromPool("NuclearBomb_Slowdown", rootPosition, new Vector3(dealtDegree * j + degreeOffset, -90, 0));
            }
            yield return new WaitForSeconds(interval);
        }
    }

    public void PlayPattern5(Transform emitter)
    {
        StartCoroutine(EmitPattern5(emitter.position));
    }

    private IEnumerator EmitPattern5(Vector3 rootPosition)
    {
        int round = 5;
        int count = 10;
        float interval = 1.5f;
        float dealtDegree = 360.0f / count;
        float degreeOffset = -15.0f;

        for (int i = 0; i < round; i++)
        {
            degreeOffset += 15.0f;
            for (int j = 0; j < count; j++)
            {
                ObjectPooler.Instance.SpawnFromPool("NuclearBomb_StopAndMove", rootPosition, new Vector3(dealtDegree * j + degreeOffset, -90, 0));
            }
            yield return new WaitForSeconds(interval);
        }
    }

    public void PlayPattern6(Transform emitter)
    {
        StartCoroutine(EmitPattern6(emitter.position));
    }

    private IEnumerator EmitPattern6(Vector3 rootPosition)
    {
        int round = 5;
        int count = 10;
        float interval = 1.5f;
        float dealtDegree = 360.0f / count;
        float degreeOffset = -15.0f;

        for (int i = 0; i < round; i++)
        {
            degreeOffset += 15.0f;
            for (int j = 0; j < count; j++)
            {
                ObjectPooler.Instance.SpawnFromPool("NuclearBomb_StopAndMove", rootPosition, new Vector3(dealtDegree * j + degreeOffset, -90, 0));
            }
            yield return new WaitForSeconds(interval);
        }
    }

}
